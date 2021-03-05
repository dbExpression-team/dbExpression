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
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class DeleteQueryExpressionExecutionPipeline<T> : IDeleteQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeDeletePipelineExecutionContext> beforeDelete;
        private readonly PipelineEventHook<AfterDeletePipelineExecutionContext> afterDelete;
        #endregion

        #region constructors
        public DeleteQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeDeletePipelineExecutionContext> beforeDelete,
            PipelineEventHook<AfterDeletePipelineExecutionContext> afterDelete
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeDelete = beforeDelete;
            this.afterDelete = afterDelete;
        }
        #endregion

        #region methods
        public int ExecuteDelete(DeleteQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.ExpressionElementAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, parameterBuilder)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, parameterBuilder, statement)));

            beforeDelete?.Invoke(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(database, expression, parameterBuilder, statement)));

            var rowsAffected = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalar<int>(
                statement,
                connection,
                cmd => { 
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)))
            );

            afterDelete?.Invoke(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(database, expression)));

            return rowsAffected;
        }

        public async Task<int> ExecuteDeleteAsync(DeleteQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.ExpressionElementAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            if (beforeAssembly is object)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, parameterBuilder)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var statement = statementBuilder.CreateSqlStatement();
            if (afterAssembly is object)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, parameterBuilder, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (beforeDelete is object)
            {
                await beforeDelete.InvokeAsync(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(database, expression, parameterBuilder, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var  rowsAffected = await database.StatementExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalarAsync<int>(
                statement,
                connection,
                async cmd =>
                {
                    if (beforeExecution is object)
                    {
                        await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement)), ct).ConfigureAwait(false);
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

            if (afterDelete is object)
            {
                await afterDelete.InvokeAsync(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(database, expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            return rowsAffected;
        }
        #endregion
    }
}
