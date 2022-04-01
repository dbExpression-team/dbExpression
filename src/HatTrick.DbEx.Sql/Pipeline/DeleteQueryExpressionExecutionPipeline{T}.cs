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
    public class DeleteQueryExpressionExecutionPipeline : IDeleteQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly SqlDatabaseRuntimeConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeDeletePipelineExecutionContext> beforeDelete;
        private readonly PipelineEventHook<AfterDeletePipelineExecutionContext> afterDelete;
        #endregion

        #region constructors
        public DeleteQueryExpressionExecutionPipeline(
            SqlDatabaseRuntimeConfiguration database,
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
        public virtual int ExecuteDelete(DeleteQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression) ?? throw new DbExpressionException("The sql statement builder is null, cannot execute a delete query without a statement builder to construct the sql statement.");

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)));
            var statement = statementBuilder.CreateSqlStatement() ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a delete query without a sql statement.");
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)));

            beforeDelete?.Invoke(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)));

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor() ?? throw new DbExpressionException("The sql statement executor is null, cannot execute a delete query without a statement executor to execute the sql statement.");
            var rowsAffected = executor.ExecuteScalar<int>(
                statement,
                connection,
                cmd => {
                    cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)))
            );

            afterDelete?.Invoke(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(database, expression)));

            return rowsAffected;
        }

        public virtual async Task<int> ExecuteDeleteAsync(DeleteQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression) ?? throw new DbExpressionException("The sql statement builder is null, cannot execute a delete query without a statement builder to construct the sql statement.");

            if (beforeAssembly is not null)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var statement = statementBuilder.CreateSqlStatement() ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a delete query without a sql statement.");
            if (afterAssembly is not null)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (beforeDelete is not null)
            {
                await beforeDelete.InvokeAsync(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor() ?? throw new DbExpressionException("The sql statement executor is null, cannot execute a delete query without a statement executor to execute the sql statement.");
            var rowsAffected = await executor.ExecuteScalarAsync<int>(
                statement,
                connection,
                async cmd =>
                {
                    cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
                    if (beforeExecution is not null)
                    {
                        await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement)), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd =>
                {
                    if (afterExecution is not null)
                    {
                        await afterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            ct.ThrowIfCancellationRequested();

            if (afterDelete is not null)
            {
                await afterDelete.InvokeAsync(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(database, expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            return rowsAffected;
        }
        #endregion
    }
}
