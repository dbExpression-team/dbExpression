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
    public class UpdateQueryExpressionExecutionPipeline<T> : IUpdateQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<BeforeUpdateAssemblyPipelineExecutionContext> beforeUpdateAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeUpdatePipelineExecutionContext> beforeUpdate;
        private readonly PipelineEventHook<AfterUpdatePipelineExecutionContext> afterUpdate;
        #endregion

        #region constructors
        public UpdateQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<BeforeUpdateAssemblyPipelineExecutionContext> beforeUpdateAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeUpdatePipelineExecutionContext> beforeUpdate,
            PipelineEventHook<AfterUpdatePipelineExecutionContext> afterUpdate
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.beforeUpdateAssembly = beforeUpdateAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeUpdate = beforeUpdate;
            this.afterUpdate = afterUpdate;
        }
        #endregion

        #region methods
        public virtual int ExecuteUpdate(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression) ?? throw new DbExpressionException("The sql statement builder is null, cannot execute an update query without a statement builder to construct the sql statement.");

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)));
            beforeUpdateAssembly?.Invoke(new Lazy<BeforeUpdateAssemblyPipelineExecutionContext>(() => new BeforeUpdateAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)));
            var statement = statementBuilder.CreateSqlStatement() ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an update query without a sql statement.");
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)));

            beforeUpdate?.Invoke(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)));

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression) ?? throw new DbExpressionException("The sql statement executor is null, cannot execute an update query without a statement executor to execute the sql statement.");
            var rowsAffected = executor.ExecuteScalar<int>(
                statement,
                connection,
                cmd => {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)))
            );

            afterUpdate?.Invoke(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(database, expression, statement)));

            return rowsAffected;
        }

        public virtual async Task<int> ExecuteUpdateAsync(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression) ?? throw new DbExpressionException("The sql statement builder is null, cannot execute an update query without a statement builder to construct the sql statement.");

            if (beforeAssembly is object)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            if (beforeUpdateAssembly is object)
            {
                await beforeUpdateAssembly.InvokeAsync(new Lazy<BeforeUpdateAssemblyPipelineExecutionContext>(() => new BeforeUpdateAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            var statement = statementBuilder.CreateSqlStatement() ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an update query without a sql statement.");
            if (afterAssembly is object)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (beforeUpdate is object)
            {
                await beforeUpdate.InvokeAsync(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression) ?? throw new DbExpressionException("The sql statement executor is null, cannot execute an update query without a statement executor to execute the sql statement.");
            var rowsAffected = await executor.ExecuteScalarAsync<int>(
                statement,
                connection,
                async cmd => {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
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

            if (afterUpdate is object)
            {
                await afterUpdate.InvokeAsync(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(database, expression, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            return rowsAffected;
        }
        #endregion
    }
}
