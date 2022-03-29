﻿#region license
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

using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using HatTrick.DbEx.Sql.Configuration;
using System.Dynamic;
using System.Linq;
using System.Data.Common;
using HatTrick.DbEx.Sql.Converter;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class StoredProcedureQueryExpressionExecutionPipeline : IStoredProcedureQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly SqlDatabaseRuntimeConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext> beforeStoredProcedure;
        private readonly PipelineEventHook<AfterStoredProcedurePipelineExecutionContext> afterStoredProcedure;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionExecutionPipeline(
            SqlDatabaseRuntimeConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext> beforeStoredProcedure,
            PipelineEventHook<AfterStoredProcedurePipelineExecutionContext> afterStoredProcedure
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeStoredProcedure = beforeStoredProcedure;
            this.afterStoredProcedure = afterStoredProcedure;
        }
        #endregion

        #region methods
        public virtual void Execute(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
        {
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                null
            );
        }

        public virtual void Execute(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection connection, Action<IDbCommand>? configureCommand)
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

        public virtual Task ExecuteAsync(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            return ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                null,
                ct
            );
        }

        public virtual async Task ExecuteAsync(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
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
        
        public virtual dynamic? ExecuteSelectDynamic(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
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
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                }
            );
            return value;
        }

        public virtual async Task<dynamic?> ExecuteSelectDynamicAsync(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
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
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public virtual IList<dynamic> ExecuteSelectDynamicList(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
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

        public virtual async Task<IList<dynamic>> ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
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

        public virtual T? ExecuteSelectValue<T>(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
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

        public virtual async Task<T?> ExecuteSelectValueAsync<T>(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
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

        public virtual IList<T> ExecuteSelectValueList<T>(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
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

        public virtual async Task<IList<T>> ExecuteSelectValueListAsync<T>(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
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

        public virtual T? ExecuteSelectObject<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection connection, Action<IDbCommand>? configureCommand)
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

        public virtual async Task<T?> ExecuteSelectObjectAsync<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
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

        public virtual IList<T> ExecuteSelectObjectList<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection connection, Action<IDbCommand>? configureCommand)
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

        public virtual async Task<IList<T>> ExecuteSelectObjectListAsync<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
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
            ISqlConnection connection,
            Action<IDbCommand>? configureCommand,
            Action<ISqlRowReader>? transform
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression) ?? throw new DbExpressionException("The sql statement builder is null, cannot execute a stored procedure without a statement builder to construct the sql statement.");

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)));
            var statement = statementBuilder.CreateSqlStatement() ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a stored procedure without a sql statement.");
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)));

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor() ?? throw new DbExpressionException("The sql statement executor is null, cannot execute a stored procedure without a statement executor to execute the sql statement.");

            beforeStoredProcedure?.Invoke(new Lazy<BeforeStoredProcedurePipelineExecutionContext>(() => new BeforeStoredProcedurePipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)));

            var converters = new SqlStatementValueConverterProvider(database.ValueConverterFactory);

            if (transform is not null)
            {
                IDbCommand? command = default;
                var reader = executor.ExecuteQuery(
                    statement,
                    connection,
                    converters,
                    cmd =>
                    {
                        command = cmd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement)));
                        configureCommand?.Invoke(cmd);
                    },
                    null
                );

                if (reader is not null)
                    transform(reader);

                MapOutputParameters(expression, command!.Parameters, statement.Parameters, database.ValueConverterFactory);
                afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, command)));
            }
            else
            {
                executor.ExecuteNonQuery(
                    statement,
                    connection,
                    cmd =>
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement)));
                        configureCommand?.Invoke(cmd);
                    },
                    cmd =>
                    {
                        MapOutputParameters(expression, cmd.Parameters, statement.Parameters, database.ValueConverterFactory);
                        afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)));
                    }
                );
            }

            afterStoredProcedure?.Invoke(new Lazy<AfterStoredProcedurePipelineExecutionContext>(() => new AfterStoredProcedurePipelineExecutionContext(database, expression)));
        }

        private async Task ExecuteStoredProcedureAsync(
            StoredProcedureQueryExpression expression,
            ISqlConnection connection,
            Action<IDbCommand>? configureCommand,
            Func<IAsyncSqlRowReader, Task>? transform,
            CancellationToken ct
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression) ?? throw new DbExpressionException("The sql statement builder is null, cannot execute a stored procedure without a statement builder to construct the sql statement.");

            if (beforeAssembly is not null)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var statement = statementBuilder.CreateSqlStatement() ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a stored procedure without a sql statement.");
            if (afterAssembly is not null)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (beforeStoredProcedure is not null)
            {
                await beforeStoredProcedure.InvokeAsync(new Lazy<BeforeStoredProcedurePipelineExecutionContext>(() => new BeforeStoredProcedurePipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor() ?? throw new DbExpressionException("The sql statement executor is null, cannot execute a stored procedure without a statement executor to execute the sql statement.");

            var converters = new SqlStatementValueConverterProvider(database.ValueConverterFactory);

            if (transform is not null)
            {
                IDbCommand? command = default;
                var reader = await executor.ExecuteQueryAsync(
                    statement,
                    connection,
                    converters,
                    async cmd =>
                    {
                        command = cmd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (beforeExecution is not null)
                        {
                            await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statementBuilder.CreateSqlStatement())), ct).ConfigureAwait(false);
                        }
                        configureCommand?.Invoke(cmd);
                    },
                    null,
                    ct
                ).ConfigureAwait(false);

                ct.ThrowIfCancellationRequested();

                if (reader is not null)
                    await transform(reader).ConfigureAwait(false);

                MapOutputParameters(expression, command!.Parameters, statement.Parameters, database.ValueConverterFactory);
                if (afterExecution is not null)
                {
                    await afterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, command)), ct).ConfigureAwait(false);
                }
            }
            else
            {
                await executor.ExecuteNonQueryAsync(
                    statement,
                    connection,
                    cmd =>
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement)));
                        configureCommand?.Invoke(cmd);
                    },
                    cmd =>
                    {
                        MapOutputParameters(expression, cmd.Parameters, statement.Parameters, database.ValueConverterFactory);
                        afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)));
                    },
                    ct
                ).ConfigureAwait(false);
            }

            if (afterStoredProcedure is not null)
            {
                await afterStoredProcedure.InvokeAsync(new Lazy<AfterStoredProcedurePipelineExecutionContext>(() => new AfterStoredProcedurePipelineExecutionContext(database, expression)), ct).ConfigureAwait(false);
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
