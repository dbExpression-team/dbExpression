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
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public sealed class StoredProcedureQueryExpressionExecutionPipeline : IStoredProcedureQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly ILogger<StoredProcedureQueryExpressionExecutionPipeline> logger;
        private readonly IDbConnectionFactory connectionFactory;
        private readonly ISqlStatementExecutor statementExecutor;
        private readonly IValueConverterFactory valueConverterFactory;
        private readonly IMapperFactory mapperFactory;
        private readonly ISqlStatementBuilder statementBuilder;
        private readonly PipelineEventSubscriptions events;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionExecutionPipeline(
            ILogger<StoredProcedureQueryExpressionExecutionPipeline> logger,
            IDbConnectionFactory connectionFactory,
            ISqlStatementExecutor statementExecutor,
            IValueConverterFactory valueConverterFactory,
            IMapperFactory mapperFactory,
            ISqlStatementBuilder statementBuilder,
            PipelineEventSubscriptions events
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
                            DbExpressionMappingException.ThrowDataMappingFailed<object>(expression, e);
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
                            DbExpressionMappingException.ThrowDataMappingFailed<object>(expression, e);
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
                    if (row is null)
                    {
                        reader.Close();
                        return;
                    }

                    value = new ExpandoObject();
                    var mapper = mapperFactory.CreateExpandoObjectMapper();
                    try
                    {
                        mapper.Map(value, row);
                    }
                    catch (Exception e)
                    {
                        DbExpressionMappingException.ThrowDataMappingFailed<ExpandoObject>(expression, e);
                    }
                    finally
                    {
                        reader.Close();
                    }
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
                    if (row is null)
                    {
                        reader.Close();
                        return;
                    }

                    value = new ExpandoObject();
                    var mapper = mapperFactory.CreateExpandoObjectMapper();
                    try
                    {
                        mapper.Map(value, row);
                    }
                    catch (Exception e)
                    {
                        DbExpressionMappingException.ThrowDataMappingFailed<ExpandoObject>(expression, e);
                    }
                    finally
                    {
                        reader.Close();
                    }
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

        public async IAsyncEnumerable<dynamic> ExecuteSelectDynamicListAsyncEnumerable(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, [EnumeratorCancellation] CancellationToken ct)
        {
            IExpandoObjectMapper? mapper = null;
            await foreach (ISqlFieldReader row in ExecuteStoredProcedureAsyncEnumerable(
                expression,
                connection,
                configureCommand,
                ct
            ))
            {
                var value = new ExpandoObject();
                if (mapper is null)
                    mapper = mapperFactory.CreateExpandoObjectMapper() ?? DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IExpandoObjectMapper>();

                mapper.Map(value, row);
                yield return value;
            }
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
                    if (field is null)
                    {
                        reader.Close();
                        return;
                    }

                    try
                    {
                        value = field.GetValue<T>();
                    }
                    catch (Exception e)
                    {
                        DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
                    }
                    finally
                    {
                        reader.Close();
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
                    if (row is null)
                    {
                        reader.Close();
                        return;
                    }

                    var field = row.ReadField();
                    if (field is null)
                        return;

                    try
                    {
                        value = field.GetValue<T>();
                    }
                    catch (Exception e)
                    {
                        DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
                    }
                    finally
                    {
                        reader.Close();
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
                        {
                            reader.Close();
                            return;
                        }

                        try
                        {
                            values.Add(field.GetValue<T>()!);
                        }
                        catch (Exception e)
                        {
                            DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
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
                        {
                            reader.Close();
                            return;
                        }

                        try
                        {
                            values.Add(field.GetValue<T>()!);
                        }
                        catch (Exception e)
                        {
                            DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async IAsyncEnumerable<T> ExecuteSelectValueListAsyncEnumerable<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (ISqlFieldReader row in ExecuteStoredProcedureAsyncEnumerable(
                expression,
                connection,
                configureCommand,
                ct
            ))
            {
                var field = row.ReadField();
                if (field is null)
                    yield break;

                yield return field.GetValue<T>()!;
            }
            yield break;
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
                    if (row is null)
                    {
                        reader.Close();
                        return;
                    }

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
                    }
                    finally
                    {
                        reader.Close();
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
                    if (row is null)
                    {
                        reader.Close();
                        return;
                    }

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
                    }
                    finally
                    {
                        reader.Close();
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
                            DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
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
                            DbExpressionMappingException.ThrowDataMappingFailed<T>(expression, e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async IAsyncEnumerable<T> ExecuteSelectObjectListAsyncEnumerable<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (ISqlFieldReader row in ExecuteStoredProcedureAsyncEnumerable(
                expression,
                connection,
                configureCommand,
                ct
            ))
            {
                yield return map(row);
            }
            yield break;
        }


        #endregion

        #region exec
        private void ExecuteStoredProcedure(
            StoredProcedureQueryExpression expression,
            ISqlConnection? connection,
            Action<IDbCommand>? configureCommand,
            Action<ISqlRowReader>? transform
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            OnBeforeStart(expression);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for stored procedure.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            OnAfterAssembly(expression, statementBuilder, statement);

            var converters = new SqlStatementValueConverterProvider(valueConverterFactory);

            ISqlConnection local = connection ?? new SqlConnector(connectionFactory);
            ISqlRowReader? reader = null;
            try
            {
                if (transform is not null)
                {
                    IDbCommand? command = default;
                    reader = statementExecutor.ExecuteQuery(
                        statement,
                        local,
                        converters,
                        cmd =>
                        {
                            command = cmd;
                            cmd.CommandType = CommandType.StoredProcedure;
                            OnBeforeCommand(expression, cmd, statement);
                            configureCommand?.Invoke(cmd);
                        },
                        cmd => OnAfterCommand(expression, cmd)
                    ); ;

                    if (reader is not null)
                        transform(reader);

                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Mapping output parameters for stored procedure.");
                    MapOutputParameters(expression, command!.Parameters, statement.Parameters, valueConverterFactory);
                }
                else
                {
                    statementExecutor.ExecuteNonQuery(
                        statement,
                        local,
                        cmd =>
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            OnBeforeCommand(expression, cmd, statement);
                            configureCommand?.Invoke(cmd);
                        },
                        cmd =>
                        {
                            OnAfterCommand(expression, cmd);

                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Mapping output parameters for stored procedure.");
                            MapOutputParameters(expression, cmd.Parameters, statement.Parameters, valueConverterFactory);
                        }
                    );
                }
            }
            finally
            {
                reader?.Dispose();
                if (connection is null) //was not provided
                    local.Dispose();
            }

            OnAfterComplete(expression);
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

            await OnBeforeStartAsync(expression, ct).ConfigureAwait(false);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for stored procedure.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            await OnAfterAssemblyAsync(expression, statementBuilder, statement, ct).ConfigureAwait(false);

            var converters = new SqlStatementValueConverterProvider(valueConverterFactory);

            ISqlConnection local = connection ?? new SqlConnector(connectionFactory);
            IAsyncSqlRowReader? reader = null;
            try
            {
                if (transform is not null)
                {
                    IDbCommand? command = default;
                    reader = await statementExecutor.ExecuteQueryAsync(
                        statement,
                        local,
                        converters,
                        async cmd =>
                        {
                            command = cmd;
                            cmd.CommandType = CommandType.StoredProcedure;
                            await OnBeforeCommandAsync(expression, cmd, statement, ct).ConfigureAwait(false);
                            if (!ct.IsCancellationRequested)
                                configureCommand?.Invoke(cmd);
                        },
                        async cmd => await OnAfterCommandAsync(expression, cmd, ct).ConfigureAwait(false),
                        ct
                    ).ConfigureAwait(false);

                    ct.ThrowIfCancellationRequested();

                    if (reader is not null)
                        await transform(reader).ConfigureAwait(false);

                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Mapping output parameters for stored procedure.");
                    MapOutputParameters(expression, command!.Parameters, statement.Parameters, valueConverterFactory);
                }
                else
                {
                    await statementExecutor.ExecuteNonQueryAsync(
                        statement,
                        local,
                        async cmd =>
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            await OnBeforeCommandAsync(expression, cmd, statement, ct).ConfigureAwait(false);
                            configureCommand?.Invoke(cmd);
                        },
                        async cmd =>
                        {
                            await OnAfterCommandAsync(expression, cmd, ct).ConfigureAwait(false);
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Mapping output parameters for stored procedure.");
                            MapOutputParameters(expression, cmd.Parameters, statement.Parameters, valueConverterFactory);
                        },
                        ct
                    ).ConfigureAwait(false);
                }
            }
            finally
            {
                reader?.Dispose();
                if (connection is null) //was not provided
                    local.Dispose();
            }

            ct.ThrowIfCancellationRequested();

            await OnAfterCompleteAsync(expression, ct).ConfigureAwait(false);
        }

        private async IAsyncEnumerable<ISqlFieldReader> ExecuteStoredProcedureAsyncEnumerable(
            StoredProcedureQueryExpression expression,
            ISqlConnection? connection,
            Action<IDbCommand>? configureCommand,
            [EnumeratorCancellation] CancellationToken ct
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            await OnBeforeStartAsync(expression, ct).ConfigureAwait(false);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for stored procedure.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            await OnAfterAssemblyAsync(expression, statementBuilder, statement, ct).ConfigureAwait(false);

            var converters = new SqlStatementValueConverterProvider(valueConverterFactory);

            var local = connection ?? new SqlConnector(connectionFactory);
            IDataParameterCollection? parameters = null;
            try
            {
                await foreach (ISqlFieldReader row in statementExecutor.ExecuteQueryAsyncEnumerable(
                    statement,
                    local,
                    converters,
                    async cmd =>
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await OnBeforeCommandAsync(expression, cmd, statement, ct).ConfigureAwait(false);

                        if (!ct.IsCancellationRequested)
                            configureCommand?.Invoke(cmd);
                    },
                    async cmd =>
                    {
                        await OnAfterCommandAsync(expression, cmd, ct).ConfigureAwait(false);
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Mapping output parameters for stored procedure.");
                        parameters = cmd.Parameters;
                    },
                    ct
                ))
                {
                    yield return row;
                };
            }
            finally
            {
                if (parameters is not null)
                    MapOutputParameters(expression, parameters, statement.Parameters, valueConverterFactory);
                if (connection is null) //was not provided
                    local.Dispose();
            }

            ct.ThrowIfCancellationRequested();

            await OnAfterCompleteAsync(expression, ct).ConfigureAwait(false);
        }

        #region events
        #region sync
        private void OnBeforeStart(StoredProcedureQueryExpression expression)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for stored procedure query.");
                    events.OnBeforeStart.Invoke(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)));
                }
                if (events.OnBeforeStoredProcedureStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before stored procedure start events for stored procedure query.");
                    events.OnBeforeStoredProcedureStart.Invoke(new Lazy<BeforeStoredProcedureStartPipelineEventContext>(() => new BeforeStoredProcedureStartPipelineEventContext(expression, statementBuilder.Parameters)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStart), "Stored Procedure", e);
            }
        }

        private void OnAfterAssembly(StoredProcedureQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement)
        {
            try
            {
                    if (events.OnAfterStoredProcedureAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after stored procedure assembly events for stored procedure query.");
                    events.OnAfterStoredProcedureAssembly?.Invoke(new Lazy<AfterStoredProcedureAssemblyPipelineEventContext>(() => new AfterStoredProcedureAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for stored procedure query.");
                    events.OnAfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssembly), "Stored Procedure", e);
            }
        }

        private void OnBeforeCommand(StoredProcedureQueryExpression expression, IDbCommand command, SqlStatement statement)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for stored procedure query.");
                    events.OnBeforeCommand?.Invoke(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)));
                }
                if (events.OnBeforeStoredProcedureCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before stored procedure command events for stored procedure query.");
                    events.OnBeforeStoredProcedureCommand?.Invoke(new Lazy<BeforeStoredProcedureCommandPipelineEventContext>(() => new BeforeStoredProcedureCommandPipelineEventContext(expression, command, statement)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommand), "Stored Procedure", e);
            }
        }

        private void OnAfterCommand(StoredProcedureQueryExpression expression, IDbCommand command)
        {
            try
            {
                if (events.OnAfterStoredProcedureCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after stored procedure command events for stored procedure query.");
                    events.OnAfterStoredProcedureCommand?.Invoke(new Lazy<AfterStoredProcedureCommandPipelineEventContext>(() => new AfterStoredProcedureCommandPipelineEventContext(expression, command)));
                }
                if (events.OnAfterCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for stored procedure query.");
                    events.OnAfterCommand?.Invoke(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommand), "Stored Procedure", e);
            }
        }

        private void OnAfterComplete(StoredProcedureQueryExpression expression)
        {
            try
            {
                if (events.OnAfterStoredProcedureComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after stored procedure complete events for stored procedure query.");
                    events.OnAfterStoredProcedureComplete?.Invoke(new Lazy<AfterStoredProcedureCompletePipelineEventContext>(() => new AfterStoredProcedureCompletePipelineEventContext(expression)));
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for stored procedure query.");
                    events.OnAfterComplete?.Invoke(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterComplete), "Stored Procedure", e);
            }
        }
        #endregion

        #region async
        private async Task OnBeforeStartAsync(StoredProcedureQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for stored procedure query.");
                    await events.OnBeforeStart.InvokeAsync(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeStoredProcedureStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before stored procedure start events for stored procedure query.");
                    await events.OnBeforeStoredProcedureStart.InvokeAsync(new Lazy<BeforeStoredProcedureStartPipelineEventContext>(() => new BeforeStoredProcedureStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStartAsync), "Stored Procedure", e);
            }
        }

        private async Task OnAfterAssemblyAsync(StoredProcedureQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterStoredProcedureAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after stored procedure assembly events for stored procedure query.");
                    await events.OnAfterStoredProcedureAssembly.InvokeAsync(new Lazy<AfterStoredProcedureAssemblyPipelineEventContext>(() => new AfterStoredProcedureAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for stored procedure query.");
                    await events.OnAfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssemblyAsync), "Stored Procedure", e);
            }
        }

        private async Task OnBeforeCommandAsync(StoredProcedureQueryExpression expression, IDbCommand command, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for stored procedure query.");
                    await events.OnBeforeCommand.InvokeAsync(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeStoredProcedureCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before stored procedure command events for stored procedure query.");
                    await events.OnBeforeStoredProcedureCommand.InvokeAsync(new Lazy<BeforeStoredProcedureCommandPipelineEventContext>(() => new BeforeStoredProcedureCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommandAsync), "Stored Procedure", e);
            }
        }

        private async Task OnAfterCommandAsync(StoredProcedureQueryExpression expression, IDbCommand command, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterStoredProcedureCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after stored procedure command events for stored procedure query.");
                    await events.OnAfterStoredProcedureCommand.InvokeAsync(new Lazy<AfterStoredProcedureCommandPipelineEventContext>(() => new AfterStoredProcedureCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
                }
                if (events.OnAfterCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for stored procedure query.");
                    await events.OnAfterCommand.InvokeAsync(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommandAsync), "Stored Procedure", e);
            }
        }

        private async Task OnAfterCompleteAsync(StoredProcedureQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterStoredProcedureComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after stored procedure complete events for stored procedure query.");
                    await events.OnAfterStoredProcedureComplete.InvokeAsync(new Lazy<AfterStoredProcedureCompletePipelineEventContext>(() => new AfterStoredProcedureCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for stored procedure query.");
                    await events.OnAfterComplete.InvokeAsync(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCompleteAsync), "Stored Procedure", e);
            }
        }
        #endregion
        #endregion

        private static void MapOutputParameters(StoredProcedureQueryExpression expression, IDataParameterCollection executedParameters, IEnumerable<ParameterizedExpression> statementParameters, IValueConverterFactory valueConverterFactory)
        {
            IValueConverter findValueConverter(ISqlOutputParameter p, Type t)
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

                var outputParameter = new OutputParameter(index, parameter.ParameterName, statementParameter.DeclaredType, parameter.Value, findValueConverter);

                values.Add(outputParameter);

                index++;
            }

            map(values);
        }
        #endregion
    }
}
