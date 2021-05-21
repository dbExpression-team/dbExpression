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
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext> beforeStoredProcedure;
        private readonly PipelineEventHook<AfterStoredProcedurePipelineExecutionContext> afterStoredProcedure;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
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
        public void Execute(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                null
            );
        }

        public void Execute(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        try
                        {
                            map(row);
                        }
                        catch
                        {
                            reader.Close();
                            throw;
                        }
                    }
                    reader.Close();
                }
            );
        }

        public Task ExecuteAsync(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            return ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                null,
                ct
            );
        }

        public async Task ExecuteAsync(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        try
                        {
                            map(row);
                        }
                        catch
                        {
                            reader.Close();
                            throw;
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }
        
        public dynamic ExecuteSelectDynamic(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            dynamic value = default;
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    value = new ExpandoObject();
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                }
            );
            return value;
        }

        public async Task<dynamic> ExecuteSelectDynamicAsync(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            dynamic value = default;
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    value = new ExpandoObject();
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<dynamic> ExecuteSelectDynamicList(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                }
            );
            return values;
        }

        public async Task<IList<dynamic>> ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public T ExecuteSelectValue<T>(StoredProcedureQueryExpression expression, Action<T> map, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            T value = default;
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field is null)
                        return;
                    else
                        reader.Close();

                    value = field.GetValue<T>();
                }
            );
            return value;
        }

        public async Task<T> ExecuteSelectValueAsync<T>(StoredProcedureQueryExpression expression, Action<T> map, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            T value = default;
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;

                    var field = row.ReadField();
                    if (field is null)
                        return;
                    else
                        reader.Close();

                    value = field.GetValue<T>();
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<T> ExecuteSelectValueList<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var values = new List<T>();
            ExecuteStoredProcedure(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        values.Add(field.GetValue<T>());
                    }
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectValueListAsync<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteStoredProcedureAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        values.Add(field.GetValue<T>());
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }
        #endregion

        private void ExecuteStoredProcedure(
            StoredProcedureQueryExpression expression,
            ISqlConnection connection,
            Action<IDbCommand> configureCommand,
            Action<ISqlRowReader> transform
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression);

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)));

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression);

            beforeStoredProcedure?.Invoke(new Lazy<BeforeStoredProcedurePipelineExecutionContext>(() => new BeforeStoredProcedurePipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)));

            var converters = new SqlStatementValueConverterProvider(database.ValueConverterFactory);

            if (transform is object)
            {
                IDbCommand command = null;
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

                if (reader is object)
                    transform(reader);

                MapOutputParameters(expression, command.Parameters, statement.Parameters, database.ValueConverterFactory);
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
            Action<IDbCommand> configureCommand,
            Func<IAsyncSqlRowReader, Task> transform,
            CancellationToken ct
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression);

            if (beforeAssembly is object)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var statement = statementBuilder.CreateSqlStatement();
            if (afterAssembly is object)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (beforeStoredProcedure is object)
            {
                await beforeStoredProcedure.InvokeAsync(new Lazy<BeforeStoredProcedurePipelineExecutionContext>(() => new BeforeStoredProcedurePipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression);

            var converters = new SqlStatementValueConverterProvider(database.ValueConverterFactory);

            if (transform is object)
            {
                IDbCommand command = null;
                var reader = await executor.ExecuteQueryAsync(
                    statement,
                    connection,
                    converters,
                    async cmd =>
                    {
                        command = cmd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (beforeExecution is object)
                        {
                            await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statementBuilder.CreateSqlStatement())), ct).ConfigureAwait(false);
                        }
                        configureCommand?.Invoke(cmd);
                    },
                    null,
                    ct
                ).ConfigureAwait(false);

                ct.ThrowIfCancellationRequested();

                if (reader is object)
                    await transform(reader).ConfigureAwait(false);

                MapOutputParameters(expression, command.Parameters, statement.Parameters, database.ValueConverterFactory);
                if (afterExecution is object)
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

            if (afterStoredProcedure is object)
            {
                await afterStoredProcedure.InvokeAsync(new Lazy<AfterStoredProcedurePipelineExecutionContext>(() => new AfterStoredProcedurePipelineExecutionContext(database, expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
        }

        private static void MapOutputParameters(StoredProcedureQueryExpression expression, IDataParameterCollection executedParameters, IList<ParameterizedExpression> statementParameters, IValueConverterFactory valueConverterFactory)
        {
            var map = (expression.BaseEntity as IOutputParameterMappingDelegateProvider)?.MapDelegate;

            if (map is null)
                return;

            IValueConverterProvider converters = null;

            var index = 0;
            var enumerator = (executedParameters as DbParameterCollection).GetEnumerator();
            while (enumerator.MoveNext())
            {
                var parameter = enumerator.Current as DbParameter;
                if (parameter.Direction != ParameterDirection.Output)
                    continue;

                if (converters is null)
                    converters = new SqlStatementValueConverterProvider(valueConverterFactory, statementParameters.Where(p => p.Parameter.Direction == ParameterDirection.Output));
                
                var converter = converters.FindConverter(index, statementParameters.ElementAt(index).DeclaredType, parameter.Value);
                map(parameter.ParameterName, converter.ConvertFromDatabase(parameter.Value));
                index++;
            }
        }
    }
}
