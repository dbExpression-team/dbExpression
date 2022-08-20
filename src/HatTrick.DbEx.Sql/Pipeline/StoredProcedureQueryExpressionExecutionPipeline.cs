#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public sealed class StoredProcedureQueryExpressionExecutionPipeline : IStoredProcedureExecutionPipeline
    {
        #region internals
        private readonly ILogger<StoredProcedureQueryExpressionExecutionPipeline> logger;
        private readonly IDbConnectionFactory connectionFactory;
        private readonly ISqlStatementExecutor statementExecutor;
        private readonly IValueConverterFactory valueConverterFactory;
        private readonly IMapperFactory mapperFactory;
        private readonly ISqlStatementBuilder statementBuilder;
        private readonly PipelineEventHooks events;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionExecutionPipeline(
            ILogger<StoredProcedureQueryExpressionExecutionPipeline> logger,
            IDbConnectionFactory connectionFactory,
            ISqlStatementExecutor statementExecutor,
            IValueConverterFactory valueConverterFactory,
            IMapperFactory mapperFactory,
            ISqlStatementBuilder statementBuilder,
            PipelineEventHooks events
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            this.statementExecutor = statementExecutor ?? throw new ArgumentNullException(nameof(statementExecutor));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.mapperFactory = mapperFactory ?? throw new ArgumentNullException(nameof(mapperFactory));
            this.statementBuilder = statementBuilder ?? throw new ArgumentNullException(nameof(statementBuilder));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
        }
        #endregion

        #region methods
        public void Execute(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                null
            );
        }

        public void Execute(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        try
                        {
                            map(row);
                        }
                        catch (Exception e)
                        {
                            reader.Close();
                            throw new DbExpressionException("Error in delegate managing the field reader.", e);
                        }
                    }
                    reader.Close();
                }
            );
        }

        public Task ExecuteAsync(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            return ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                null,
                ct
            );
        }

        public async Task ExecuteAsync(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            map(row);
                        }
                        catch (Exception e)
                        {
                            reader.Close();
                            throw new DbExpressionException("Error in delegate managing the field reader.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }
        
        public dynamic? ExecuteSelectDynamic(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            dynamic? value = default;
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    value = new ExpandoObject();
                    var mapper = mapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                }
            );
            return value;
        }

        public async Task<dynamic?> ExecuteSelectDynamicAsync(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            dynamic? value = default;
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    value = new ExpandoObject();
                    var mapper = mapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<dynamic> ExecuteSelectDynamicList(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            var values = new List<dynamic>();
            var mapper = mapperFactory.CreateExpandoObjectMapper();
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                    reader.Close();
                }
            );
            return values;
        }

        public async Task<IList<dynamic>> ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            var values = new List<dynamic>();
            var mapper = mapperFactory.CreateExpandoObjectMapper();
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public T? ExecuteSelectValue<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            T? value = default;
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    reader.Close();
                    if (field is null)
                        return;

                    try
                    {
                        value = field.GetValue<T>();
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                    }
                }
            );
            return value;
        }

        public async Task<T?> ExecuteSelectValueAsync<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            T? value = default;
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    var field = row.ReadField();
                    if (field is null)
                        return;

                    try
                    {
                        value = field.GetValue<T>();
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<T> ExecuteSelectValueList<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            var values = new List<T>();
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        try
                        {
                            values.Add(field.GetValue<T>()!);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                        }
                    }
                    reader.Close();
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectValueListAsync<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        try
                        {
                            values.Add(field.GetValue<T>()!);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public T? ExecuteSelectObject<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            T? value = default;
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error converting values to {typeof(T)}.", e);
                    }
                }
            );
            return value;
        }

        public async Task<T?> ExecuteSelectObjectAsync<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            T? value = default;
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error converting values to {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<T> ExecuteSelectObjectList<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            var values = new List<T>();
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        try
                        {
                            values.Add(map(row));
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to {typeof(T)}.", e);
                        }
                    }
                    reader.Close();
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectObjectListAsync<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            values.Add(map(row));
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to {typeof(T)}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }
        #endregion

        private void ExecuteStoredProcedure(
            StoredProcedureQueryExpression expression,
            ISqlConnection? connection,
            Action<IDbCommand>? configureCommand,
            Action<ISqlRowReader>? transform
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for stored procedure.");
                events.BeforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)));
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for stored procedure.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a stored procedure without a sql statement.");

            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for stored procedure.");
                events.AfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)));
            }

            if (events.BeforeStoredProcedure is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before update events for stored procedure.");
                events.BeforeStoredProcedure?.Invoke(new Lazy<BeforeStoredProcedurePipelineExecutionContext>(() => new BeforeStoredProcedurePipelineExecutionContext(expression, statement, statementBuilder.Parameters)));
            }

            var converters = new SqlStatementValueConverterProvider(valueConverterFactory);

            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                if (transform is not null)
                {
                    IDbCommand? command = default;
                    var reader = statementExecutor.ExecuteQuery(
                        statement,
                        local,
                        converters,
                        cmd =>
                        {
                            command = cmd;
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before execution events for stored procedure.");
                            events.BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)));
                            configureCommand?.Invoke(cmd);
                        },
                        null
                    );

                    if (reader is not null)
                        transform(reader);

                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Mapping output parameters for stored procedure.");
                    MapOutputParameters(expression, command!.Parameters, statement.Parameters, valueConverterFactory);
                
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for stored procedure.");
                        events.AfterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, command)));
                    }
                }
                else
                {
                    statementExecutor.ExecuteNonQuery(
                        statement,
                        local,
                        cmd =>
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before execution events for stored procedure.");
                            events.BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)));
                            configureCommand?.Invoke(cmd);
                        },
                        cmd =>
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Mapping output parameters for stored procedure.");
                            MapOutputParameters(expression, cmd.Parameters, statement.Parameters, valueConverterFactory);
                        
                            if (events.AfterExecution is not null)
                            {
                                if (logger.IsEnabled(LogLevel.Trace))
                                    logger.LogTrace("Invoking after execution events for stored procedure.");
                                events.AfterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)));
                            }
                        }
                    );
                }
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            if (events.AfterStoredProcedure is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after update events for stored procedure.");
                events.AfterStoredProcedure?.Invoke(new Lazy<AfterStoredProcedurePipelineExecutionContext>(() => new AfterStoredProcedurePipelineExecutionContext(expression)));
            }
        }

        private async Task ExecuteStoredProcedureAsync(
            StoredProcedureQueryExpression expression,
            ISqlConnection? connection,
            Action<IDbCommand>? configureCommand,
            Func<IAsyncSqlRowReader, Task>? transform,
            CancellationToken ct
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for stored procedure.");
                await events.BeforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for stored procedure.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a stored procedure without a sql statement.");
            
            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for stored procedure.");
                await events.AfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (events.BeforeStoredProcedure is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before update events for stored procedure.");
                await events.BeforeStoredProcedure.InvokeAsync(new Lazy<BeforeStoredProcedurePipelineExecutionContext>(() => new BeforeStoredProcedurePipelineExecutionContext(expression, statement, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var converters = new SqlStatementValueConverterProvider(valueConverterFactory);

            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                if (transform is not null)
                {
                    IDbCommand? command = default;
                    var reader = await statementExecutor.ExecuteQueryAsync(
                        statement,
                        local,
                        converters,
                        async cmd =>
                        {
                            command = cmd;
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (events.BeforeExecution is not null)
                            {
                                if (logger.IsEnabled(LogLevel.Trace))
                                    logger.LogTrace("Invoking before execution events for stored procedure.");
                                await events.BeforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)), ct).ConfigureAwait(false);
                            }
                            configureCommand?.Invoke(cmd);
                        },
                        null,
                        ct
                    ).ConfigureAwait(false);

                    ct.ThrowIfCancellationRequested();

                    if (reader is not null)
                        await transform(reader).ConfigureAwait(false);

                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Mapping output parameters for stored procedure.");
                    MapOutputParameters(expression, command!.Parameters, statement.Parameters, valueConverterFactory);
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for stored procedure.");
                        await events.AfterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, command)), ct).ConfigureAwait(false);
                    }
                }
                else
                {
                    await statementExecutor.ExecuteNonQueryAsync(
                        statement,
                        local,
                        cmd =>
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before execution events for stored procedure.");
                            events.BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)));
                            configureCommand?.Invoke(cmd);
                        },
                        cmd =>
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Mapping output parameters for stored procedure.");
                            MapOutputParameters(expression, cmd.Parameters, statement.Parameters, valueConverterFactory);
                        
                            if (events.AfterExecution is not null)
                            {
                                if (logger.IsEnabled(LogLevel.Trace))
                                    logger.LogTrace("Invoking after execution events for stored procedure.");
                                events.AfterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)));
                            }
                        },
                        ct
                    ).ConfigureAwait(false);
                }
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            if (events.AfterStoredProcedure is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after update events for stored procedure.");
                await events.AfterStoredProcedure.InvokeAsync(new Lazy<AfterStoredProcedurePipelineExecutionContext>(() => new AfterStoredProcedurePipelineExecutionContext(expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
        }

        private static void MapOutputParameters(StoredProcedureQueryExpression expression, IDataParameterCollection executedParameters, IList<ParameterizedExpression> statementParameters, IValueConverterFactory valueConverterFactory)
        {
            IValueConverter finder(ISqlOutputParameter p, Type t)
            {
                if (p.RawValue is DBNull && !t.IsNullableType() && t.IsConvertibleToNullableType())
                    return valueConverterFactory.CreateConverter(typeof(Nullable<>).MakeGenericType(t));

                return valueConverterFactory.CreateConverter(t);
            }

            var map = (expression.BaseEntity as IOutputParameterMappingDelegateProvider)?.MapDelegate;

            //map not provided or there are no output parameters, nothing to do
            if (map is null || !statementParameters.Any(p => p.Parameter.Direction != ParameterDirection.Input))
                return;

            var provider = new SqlStatementValueConverterProvider(valueConverterFactory, statementParameters.Where(p => p.Parameter.Direction != ParameterDirection.Input));
            var values = new SqlOutputParameterList();

            var index = 0;
            var enumerator = executedParameters.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is not DbParameter parameter)
                    continue;

                if (parameter.Direction == ParameterDirection.Input)
                    continue;

                var statementParameter = statementParameters.Single(x => x.Parameter.ParameterName == parameter.ParameterName);

                var outputParameter = new OutputParameter(index, parameter.ParameterName, statementParameter.DeclaredType, parameter.Value, finder);

                values.Add(outputParameter);

                index++;
            }

            map(values);
        }
    }
}
