#region license
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
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Builder
{
    public class StoredProcedureQueryExpressionBuilder<TDatabase, TEntity> : QueryExpressionBuilder<TDatabase>,
        StoredProcedureContinuation<TDatabase, TEntity>,
        SelectDynamicStoredProcedureContinuation<TDatabase, TEntity>,
        SelectDynamicsStoredProcedureContinuation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, StoredProcedure
    {
        #region internals
        protected IQueryExpressionExecutionPipelineFactory ExecutionPipelineFactory { get; private set; }
        public StoredProcedureQueryExpression StoredProcedureQueryExpression { get; private set; }
        private StoredProcedure _entity;
        protected override QueryExpression Expression => StoredProcedureQueryExpression;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            StoredProcedure entity
        )
        {
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
            StoredProcedureQueryExpression = queryExpressionFactory.CreateQueryExpression<StoredProcedureQueryExpression>();
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            if (StoredProcedureQueryExpression.BaseEntity is null)
                StoredProcedureQueryExpression.BaseEntity = _entity;
        }

        protected StoredProcedureQueryExpressionBuilder(
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            StoredProcedureQueryExpression expression
        )
        {
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
            StoredProcedureQueryExpression = expression;
            _entity = expression.BaseEntity!;
        }
        #endregion

        #region methods
        #region StoredProcedureContinuation
        /// <inheritdoc />
        SelectValueStoredProcedureContinuation<TDatabase, TEntity, TValue> StoredProcedureContinuation<TDatabase, TEntity>.GetValue<TValue>()
            => new SelectValueStoredProcedureQueryExpressionBuilder<TDatabase, TEntity, TValue>(
                    ExecutionPipelineFactory,
                    StoredProcedureQueryExpression
                );

        /// <inheritdoc />
        SelectValuesStoredProcedureContinuation<TDatabase, TEntity, TValue> StoredProcedureContinuation<TDatabase, TEntity>.GetValues<TValue>()
            => new SelectValuesStoredProcedureQueryExpressionBuilder<TDatabase, TEntity, TValue>(
                    ExecutionPipelineFactory,
                    StoredProcedureQueryExpression
                );

        /// <inheritdoc />
        SelectObjectStoredProcedureContinuation<TDatabase, TEntity, TValue> StoredProcedureContinuation<TDatabase, TEntity>.GetValue<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectStoredProcedureQueryExpressionBuilder<TDatabase, TEntity, TValue>(
                    ExecutionPipelineFactory,
                    StoredProcedureQueryExpression,
                    map
                );

        /// <inheritdoc />
        SelectObjectsStoredProcedureContinuation<TDatabase, TEntity, TValue> StoredProcedureContinuation<TDatabase, TEntity>.GetValues<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectsStoredProcedureQueryExpressionBuilder<TDatabase, TEntity, TValue>(
                    ExecutionPipelineFactory,
                    StoredProcedureQueryExpression,
                    map
                );

        /// <inheritdoc />
        MapValuesStoredProcedureContinuation<TDatabase, TEntity> StoredProcedureContinuation<TDatabase, TEntity>.MapValues(Action<ISqlFieldReader> row)
            => new MapValuesStoredProcedureQueryExpressionBuilder<TDatabase, TEntity>(
                    ExecutionPipelineFactory,
                    StoredProcedureQueryExpression,
                    row
                );

        /// <inheritdoc />
        SelectDynamicStoredProcedureContinuation<TDatabase, TEntity> StoredProcedureContinuation<TDatabase, TEntity>.GetValue()
            => this;

        /// <inheritdoc />
        SelectDynamicsStoredProcedureContinuation<TDatabase, TEntity> StoredProcedureContinuation<TDatabase, TEntity>.GetValues()
            => this;
        #endregion

        #region SelectDynamicStoredProcedureTermination
        /// <inheritdoc />
        dynamic? SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.Execute()
        {
            return ExecuteDynamicPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecuteDynamicPipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteDynamicPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
		Task<dynamic?> SelectDynamicStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
            => ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().ExecuteSelectDynamic(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual Task<dynamic?> ExecuteDynamicPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().ExecuteSelectDynamicAsync(StoredProcedureQueryExpression, connection, configureCommand, ct);

        #endregion

        #region SelectDynamicStoredProcedureTermination
        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.Execute()
        {
            return ExecuteDynamicListPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicListPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsyncEnumerable(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteDynamicListPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken)
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
        Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        IAsyncEnumerable<dynamic> SelectDynamicsStoredProcedureTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteDynamicListPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        private IList<dynamic> ExecuteDynamicListPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectDynamicList(StoredProcedureQueryExpression, connection, configureCommand);

        private Task<IList<dynamic>> ExecuteDynamicListPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression, connection, configureCommand, ct);

        private IAsyncEnumerable<dynamic> ExecuteDynamicListPipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsyncEnumerable(StoredProcedureQueryExpression, connection, configureCommand, ct);

        protected IStoredProcedureQueryExpressionExecutionPipeline CreateExecutionPipeline()
            =>  ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline() ??
                    DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IStoredProcedureQueryExpressionExecutionPipeline>();
        #endregion

        #region StoredProcedureTermination
        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase, TEntity>.Execute()
        {
            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase, TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task StoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task StoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task StoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task StoredProcedureTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
