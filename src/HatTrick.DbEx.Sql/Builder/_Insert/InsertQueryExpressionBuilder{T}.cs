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
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class InsertQueryExpressionBuilder<TEntity> : QueryExpressionBuilder,
        InsertEntity<TEntity>,
        InsertEntities<TEntity>,
        InsertEntityTermination<TEntity>,
        InsertEntitiesTermination<TEntity>,
        InsertEntityTermination,
        InsertEntitiesTermination
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly InsertQueryExpression _expression;
        private readonly IEnumerable<TEntity> _instances;
        protected Func<IInsertQueryExecutionPipeline> ExecutionPipelineFactory { get; private set; }
        protected override QueryExpression Expression => InsertQueryExpression;
        public InsertQueryExpression InsertQueryExpression => _expression;
        #endregion

        #region constructors
        public InsertQueryExpressionBuilder(
            InsertQueryExpression expression,
            IEnumerable<TEntity> instances,
            Func<IInsertQueryExecutionPipeline> executionPipelineFactory
        )
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _instances = instances ?? throw new ArgumentNullException(nameof(instances));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region methods
        #region InsertEntity<TEntity>
        /// <inheritdoc />
        InsertEntityTermination<TEntity> InsertEntity<TEntity>.Into(Table<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        /// <inheritdoc />
        InsertEntitiesTermination<TEntity> InsertEntities<TEntity>.Into(Table<TEntity> entity)
        {
            Into(entity);
            return this;
        }
        #endregion

        protected virtual void Into(Table<TEntity> entity)
        {
            var i = 0;
            InsertQueryExpression.Into = entity;
            InsertQueryExpression.Inserts = _instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, (entity.BuildInclusiveInsertExpression(x) as IExpressionListProvider<InsertExpression>).Expressions));
            InsertQueryExpression.Outputs = entity.BuildInclusiveSelectExpression().Expressions.Select(x => x.AsFieldExpression()).Where(x => x is not null).Cast<FieldExpression>().ToList();
        }

        #region InsertEntityTermination
        /// <inheritdoc />
        void InsertEntityTermination.Execute()
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void InsertEntityTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void InsertEntityTermination.Execute(ISqlConnection connection)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void InsertEntityTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task InsertEntityTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntityTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntityTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntityTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region InsertEntitiesTermination
        /// <inheritdoc />
        void InsertEntitiesTermination.Execute()
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void InsertEntitiesTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void InsertEntitiesTermination.Execute(ISqlConnection connection)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void InsertEntitiesTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task InsertEntitiesTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntitiesTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntitiesTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        async Task InsertEntitiesTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        #endregion
        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteInsert<TEntity>(InsertQueryExpression, connection, configureCommand);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteInsertAsync<TEntity>(InsertQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
        #endregion
    }
}
