﻿#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Sql.Connection;
using DbExpression.Sql.Executor;
using DbExpression.Sql.Expression;
using DbExpression.Sql.Pipeline;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Builder
{
    public class MapValuesStoredProcedureQueryExpressionBuilder<TDatabase, TEntity> : StoredProcedureQueryExpressionBuilder<TDatabase, TEntity>,
        StoredProcedureContinuation<TDatabase, TEntity>,
        MapValuesStoredProcedureContinuation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, StoredProcedure
    {
        #region internals
        private readonly Action<ISqlFieldReader> map;
        #endregion

        #region interface
        Action<ISqlFieldReader> MapValuesStoredProcedureTermination<TDatabase, TEntity>.Map => map;
        #endregion

        #region constructors
        public MapValuesStoredProcedureQueryExpressionBuilder(
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            StoredProcedureQueryExpression expression
        ) : base(executionPipelineFactory, expression)
        {
            this.map = _ => { };
        }

        public MapValuesStoredProcedureQueryExpressionBuilder(
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            StoredProcedureQueryExpression expression,
            Action<ISqlFieldReader> map
        ) : base(executionPipelineFactory, expression)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }
        #endregion

        #region methods
        #region MapValuesStoredProcedureTermination
        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase, TEntity>.Execute()
        {
            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase, TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task MapValuesStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task MapValuesStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task MapValuesStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task MapValuesStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        protected void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().Execute(StoredProcedureQueryExpression, map, connection, configureCommand);

        protected Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().ExecuteAsync(StoredProcedureQueryExpression, map, connection, configureCommand, ct);
        #endregion
        #endregion
    }
}
