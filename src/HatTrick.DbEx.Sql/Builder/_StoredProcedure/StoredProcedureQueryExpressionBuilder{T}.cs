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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class StoredProcedureQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        StoredProcedureContinuation<TDatabase>,
        SelectDynamicStoredProcedureContinuation<TDatabase>,
        SelectDynamicsStoredProcedureContinuation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly StoredProcedureQueryExpression _expression;
        private readonly StoredProcedure _entity;
        protected override QueryExpression Expression => StoredProcedureQueryExpression;
        public StoredProcedureQueryExpression StoredProcedureQueryExpression => _expression;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionBuilder(StoredProcedureQueryExpression expression, SqlDatabaseRuntimeConfiguration config)
            : base(config)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _entity = _expression.BaseEntity ?? throw new ArgumentNullException(nameof(expression.BaseEntity));
        }

        public StoredProcedureQueryExpressionBuilder(StoredProcedureQueryExpression expression, SqlDatabaseRuntimeConfiguration config, StoredProcedure entity)
            : base(config)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            if (_expression.BaseEntity is null)
                _expression.BaseEntity = _entity;
        }
        #endregion

        #region methods
        #region StoredProcedureContinuation
        /// <inheritdoc />
        SelectValueStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValue<TValue>()
            => new SelectValueStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(StoredProcedureQueryExpression, Configuration);

        /// <inheritdoc />
        SelectValuesStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValues<TValue>()
            => new SelectValuesStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(StoredProcedureQueryExpression, Configuration);

        /// <inheritdoc />
        SelectObjectStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValue<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(StoredProcedureQueryExpression, Configuration, map);

        /// <inheritdoc />
        SelectObjectsStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValues<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectsStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(StoredProcedureQueryExpression, Configuration, map);

        /// <inheritdoc />
        MapValuesStoredProcedureContinuation<TDatabase> StoredProcedureContinuation<TDatabase>.MapValues(Action<ISqlFieldReader> row)
            => new MapValuesStoredProcedureQueryExpressionBuilder<TDatabase>(StoredProcedureQueryExpression, Configuration, row);

        /// <inheritdoc />
        SelectDynamicStoredProcedureContinuation<TDatabase> StoredProcedureContinuation<TDatabase>.GetValue()
            => this;

        /// <inheritdoc />
        SelectDynamicsStoredProcedureContinuation<TDatabase> StoredProcedureContinuation<TDatabase>.GetValues()
            => this;
        #endregion

        #region SelectDynamicStoredProcedureTermination
        /// <inheritdoc />
        dynamic? SelectDynamicStoredProcedureTermination<TDatabase>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteDynamicPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteDynamicPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteDynamicPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteDynamicPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteDynamicPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual dynamic? ExecuteDynamicPipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateStoredProcedureExecutionPipeline().ExecuteSelectDynamic(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task<dynamic?> ExecuteDynamicPipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await CreateStoredProcedureExecutionPipeline().ExecuteSelectDynamicAsync(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion

        #region SelectDynamicStoredProcedureTermination
        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteDynamicListPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicListPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteDynamicListPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteDynamicListPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
                return await ExecuteDynamicListPipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicListPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteDynamicListPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicListPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual IList<dynamic> ExecuteDynamicListPipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateStoredProcedureExecutionPipeline().ExecuteSelectDynamicList(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task<IList<dynamic>> ExecuteDynamicListPipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await CreateStoredProcedureExecutionPipeline().ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion

        #region StoredProcedureTermination
        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateStoredProcedureExecutionPipeline().Execute(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await CreateStoredProcedureExecutionPipeline().ExecuteAsync(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);

        protected virtual IStoredProcedureQueryExpressionExecutionPipeline CreateStoredProcedureExecutionPipeline()
        {
            return Configuration.ExecutionPipelineFactory?.CreateQueryExecutionPipeline(Configuration, StoredProcedureQueryExpression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{GetType()}', please review and ensure the correct configuration for DbExpression.");
        }
        #endregion
        #endregion
    }
}
