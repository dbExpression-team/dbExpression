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
        protected Func<IStoredProcedureQueryExpressionExecutionPipeline> ExecutionPipelineFactory { get; private set; }
        protected override QueryExpression Expression => StoredProcedureQueryExpression;
        public StoredProcedureQueryExpression StoredProcedureQueryExpression => _expression;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionBuilder(
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureQueryExpressionExecutionPipeline> executionPipelineFactory
        )
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _entity = _expression.BaseEntity ?? throw new ArgumentNullException(nameof(_expression.BaseEntity));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }

        public StoredProcedureQueryExpressionBuilder(
            StoredProcedureQueryExpression expression,
            StoredProcedure entity,
            Func<IStoredProcedureQueryExpressionExecutionPipeline> executionPipelineFactory
        )
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            if (_expression.BaseEntity is null)
                _expression.BaseEntity = _entity;
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region methods
        #region StoredProcedureContinuation
        /// <inheritdoc />
        SelectValueStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValue<TValue>()
            => new SelectValueStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory
                );

        /// <inheritdoc />
        SelectValuesStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValues<TValue>()
            => new SelectValuesStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory
                );

        /// <inheritdoc />
        SelectObjectStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValue<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory,
                    map
                );

        /// <inheritdoc />
        SelectObjectsStoredProcedureContinuation<TDatabase, TValue> StoredProcedureContinuation<TDatabase>.GetValues<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectsStoredProcedureQueryExpressionBuilder<TDatabase, TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory,
                    map
                );

        /// <inheritdoc />
        MapValuesStoredProcedureContinuation<TDatabase> StoredProcedureContinuation<TDatabase>.MapValues(Action<ISqlFieldReader> row)
            => new MapValuesStoredProcedureQueryExpressionBuilder<TDatabase>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory,
                    row
                );

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
            return ExecuteDynamicPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecuteDynamicPipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteDynamicPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicPipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        protected virtual dynamic? ExecuteDynamicPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectDynamic(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual Task<dynamic?> ExecuteDynamicPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => ExecutionPipelineFactory().ExecuteSelectDynamicAsync(StoredProcedureQueryExpression, connection, configureCommand, ct);

        #endregion

        #region SelectDynamicStoredProcedureTermination
        /// <inheritdoc />
        IEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute()
        {
            return ExecuteDynamicListPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicListPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task<IEnumerable<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsyncEnumerable(CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsyncEnumerable(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IEnumerable<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IEnumerable<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipelineAsyncEnumerable(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IEnumerable<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        private IEnumerable<dynamic> ExecuteDynamicListPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectDynamicList(StoredProcedureQueryExpression, connection, configureCommand);

        private Task<IEnumerable<dynamic>> ExecuteDynamicListPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression, connection, configureCommand, ct);

        private IAsyncEnumerable<dynamic> ExecuteDynamicListPipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsyncEnumerable(StoredProcedureQueryExpression, connection, configureCommand, ct);

        private IStoredProcedureQueryExpressionExecutionPipeline CreateExecutionPipeline()
            => ExecutionPipelineFactory()
                    ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{StoredProcedureQueryExpression.GetType()}'.");
        #endregion

        #region StoredProcedureTermination
        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute()
        {
            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task StoredProcedureTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task StoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task StoredProcedureTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task StoredProcedureTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().Execute(StoredProcedureQueryExpression, connection, configureCommand);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteAsync(StoredProcedureQueryExpression, connection, configureCommand, ct);
        #endregion
        #endregion
    }
}
