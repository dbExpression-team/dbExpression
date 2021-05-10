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

﻿using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class InsertQueryExpressionExecutionPipeline<T> : IInsertQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeInsertPipelineExecutionContext> beforeInsert;
        private readonly PipelineEventHook<AfterInsertPipelineExecutionContext> afterInsert;
        #endregion

        #region constructors
        public InsertQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeInsertPipelineExecutionContext> beforeInsert,
            PipelineEventHook<AfterInsertPipelineExecutionContext> afterInsert
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeInsert = beforeInsert;
            this.afterInsert = afterInsert;
        }
        #endregion

        #region methods
        public virtual void ExecuteInsert(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression);

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)));

            if (beforeInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                    beforeInsert?.Invoke(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(database, expression, insert.Entity, statementBuilder.Parameters, statement)));
            }

            var fields = new List<FieldExpression> { null }.Concat(expression.Outputs).ToList();

            var reader = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteQuery(
                statement,
                connection,
                new SqlStatementValueConverterProvider(fields, database.ValueConverterFactory),
                cmd => { 
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement)));
                    configureCommand?.Invoke(cmd);
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)))
            );

            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);

            ISqlFieldReader row;
            while ((row = reader.ReadRow()) is object)
            {
                var index = 0;
                try
                {
                    index = row.ReadField().GetValue<int>();
                }
                catch (InvalidCastException e)
                {
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.", e);
                }
                var entity = expression.Inserts.Single(x => x.Key == Convert.ToInt32(index)).Value.Entity;
                mapper.Map(row, entity as T);
            }

            if (afterInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                    afterInsert?.Invoke(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(database, expression, insert.Entity)));
            }
        }

        public virtual async Task ExecuteInsertAsync(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
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

            if (beforeInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                {
                    await beforeInsert.InvokeAsync(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(database, expression, insert.Entity, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }

            var reader = await database.StatementExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteQueryAsync(
                statement,
                connection,
                new SqlStatementValueConverterProvider(new List<FieldExpression> { null }.Concat(expression.Outputs).ToList(), database.ValueConverterFactory),
                async cmd =>
                {
                    if (beforeExecution is object)
                    {
                        await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statementBuilder.CreateSqlStatement())), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd =>
                {
                    if (afterExecution is object)
                    {
                        await afterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            ct.ThrowIfCancellationRequested();

            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);

            ISqlFieldReader row;
            while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
            {
                var index = 0;
                try
                {
                    index = row.ReadField().GetValue<int>();
                }
                catch (InvalidCastException e)
                {
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.", e);
                }
                var entity = expression.Inserts.Single(x => x.Key == Convert.ToInt32(index)).Value.Entity;
                mapper.Map(row, entity as T);
            }

            if (afterInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                {
                    await afterInsert.InvokeAsync(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(database, expression, insert.Entity)), ct).ConfigureAwait(false);
                }
                ct.ThrowIfCancellationRequested();
            }
        }
        #endregion
    }
}
