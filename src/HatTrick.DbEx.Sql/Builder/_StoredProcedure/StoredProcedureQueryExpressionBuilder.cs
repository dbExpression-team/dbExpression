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
    public class StoredProcedureQueryExpressionBuilder : QueryExpressionBuilder,
        StoredProcedureContinuation,
        SelectDynamicStoredProcedureContinuation,
        SelectDynamicsStoredProcedureContinuation
    {
        #region internals
        private readonly StoredProcedureQueryExpression _expression;
        private readonly StoredProcedure _entity;
        protected Func<IStoredProcedureExecutionPipeline> ExecutionPipelineFactory { get; private set; }
        protected override QueryExpression Expression => StoredProcedureQueryExpression;
        public StoredProcedureQueryExpression StoredProcedureQueryExpression => _expression;
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionBuilder(
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureExecutionPipeline> executionPipelineFactory
        )
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _entity = _expression.BaseEntity ?? throw new ArgumentNullException(nameof(_expression.BaseEntity));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }

        public StoredProcedureQueryExpressionBuilder(
            StoredProcedureQueryExpression expression,
            StoredProcedure entity,
            Func<IStoredProcedureExecutionPipeline> executionPipelineFactory
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
        SelectValueStoredProcedureContinuation<TValue> StoredProcedureContinuation.GetValue<TValue>()
            => new SelectValueStoredProcedureQueryExpressionBuilder<TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory
                );

        /// <inheritdoc />
        SelectValuesStoredProcedureContinuation<TValue> StoredProcedureContinuation.GetValues<TValue>()
            => new SelectValuesStoredProcedureQueryExpressionBuilder<TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory
                );

        /// <inheritdoc />
        SelectObjectStoredProcedureContinuation<TValue> StoredProcedureContinuation.GetValue<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectStoredProcedureQueryExpressionBuilder<TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory,
                    map
                );

        /// <inheritdoc />
        SelectObjectsStoredProcedureContinuation<TValue> StoredProcedureContinuation.GetValues<TValue>(Func<ISqlFieldReader, TValue> map)
            => new SelectObjectsStoredProcedureQueryExpressionBuilder<TValue>(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory,
                    map
                );

        /// <inheritdoc />
        MapValuesStoredProcedureContinuation StoredProcedureContinuation.MapValues(Action<ISqlFieldReader> row)
            => new MapValuesStoredProcedureQueryExpressionBuilder(
                    StoredProcedureQueryExpression,
                    ExecutionPipelineFactory,
                    row
                );

        /// <inheritdoc />
        SelectDynamicStoredProcedureContinuation StoredProcedureContinuation.GetValue()
            => this;

        /// <inheritdoc />
        SelectDynamicsStoredProcedureContinuation StoredProcedureContinuation.GetValues()
            => this;
        #endregion

        #region SelectDynamicStoredProcedureTermination
        /// <inheritdoc />
        dynamic? SelectDynamicStoredProcedureTermination.Execute()
        {
            return ExecuteDynamicPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination.Execute(int commandTimeout)
        {
            return ExecuteDynamicPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		dynamic? SelectDynamicStoredProcedureTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteDynamicPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecuteDynamicPipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicPipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<dynamic?> SelectDynamicStoredProcedureTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual dynamic? ExecuteDynamicPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectDynamic(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task<dynamic?> ExecuteDynamicPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await ExecutionPipelineFactory().ExecuteSelectDynamicAsync(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion

        #region SelectDynamicStoredProcedureTermination
        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination.Execute()
        {
            return ExecuteDynamicListPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination.Execute(ISqlConnection connection)
        {
            return ExecuteDynamicListPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination.Execute(int commandTimeout)
        {
            return ExecuteDynamicListPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsStoredProcedureTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteDynamicListPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecuteDynamicListPipelineAsync(
                    null,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicListPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicListPipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsStoredProcedureTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteDynamicListPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual IList<dynamic> ExecuteDynamicListPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectDynamicList(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task<IList<dynamic>> ExecuteDynamicListPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await ExecutionPipelineFactory().ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion

        #region StoredProcedureTermination
        /// <inheritdoc />
        void StoredProcedureTermination.Execute()
        {
            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination.Execute(ISqlConnection connection)
        {
            ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination.Execute(int commandTimeout)
        {
            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void StoredProcedureTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task StoredProcedureTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().Execute(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await ExecutionPipelineFactory().ExecuteAsync(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
