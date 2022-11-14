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
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class MapValuesStoredProcedureQueryExpressionBuilder<TDatabase> : StoredProcedureQueryExpressionBuilder<TDatabase>,
        StoredProcedureContinuation<TDatabase>,
        MapValuesStoredProcedureContinuation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Action<ISqlFieldReader> map;
        #endregion

        #region interface
        Action<ISqlFieldReader> MapValuesStoredProcedureTermination<TDatabase>.Map => map;
        #endregion

        #region constructors
        public MapValuesStoredProcedureQueryExpressionBuilder(
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureQueryExpressionExecutionPipeline> executionPipelineFactory
        ) : base(expression, executionPipelineFactory)
        {
            this.map = _ => { };
        }

        public MapValuesStoredProcedureQueryExpressionBuilder(
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureQueryExpressionExecutionPipeline> executionPipelineFactory,
            Action<ISqlFieldReader> map
        ) : base(expression, executionPipelineFactory)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }
        #endregion

        #region methods
        #region MapValuesStoredProcedureTermination
        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute()
        {
            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
            => ExecutionPipelineFactory().Execute(StoredProcedureQueryExpression, map, connection, configureCommand);

        protected Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => ExecutionPipelineFactory().ExecuteAsync(StoredProcedureQueryExpression, map, connection, configureCommand, ct);
        #endregion
        #endregion
    }
}
