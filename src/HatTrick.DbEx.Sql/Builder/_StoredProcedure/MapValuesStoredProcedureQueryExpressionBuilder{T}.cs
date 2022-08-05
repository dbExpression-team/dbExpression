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
            ISqlDatabaseRuntime database,
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureExecutionPipeline<TDatabase>> executionPipelineFactory
        ) : base(database, expression, executionPipelineFactory)
        {
            this.map = _ => { };
        }

        public MapValuesStoredProcedureQueryExpressionBuilder(
            ISqlDatabaseRuntime database,
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureExecutionPipeline<TDatabase>> executionPipelineFactory,
            Action<ISqlFieldReader> map
        ) : base(database, expression, executionPipelineFactory)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }
        #endregion

        #region methods
        #region MapValuesStoredProcedureTermination
        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute()
        {
            using var connection = Database.GetConnection();
            ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            using var connection = Database.GetConnection();
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void MapValuesStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task MapValuesStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected override void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().Execute(StoredProcedureQueryExpression, map, connection, configureCommand);

        protected override async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await ExecutionPipelineFactory().ExecuteAsync(StoredProcedureQueryExpression, map, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
