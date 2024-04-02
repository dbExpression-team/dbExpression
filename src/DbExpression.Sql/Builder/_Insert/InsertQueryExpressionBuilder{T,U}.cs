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
using DbExpression.Sql.Expression;
using DbExpression.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Builder
{
    public class InsertQueryExpressionBuilder<TDatabase, TEntity> : QueryExpressionBuilder<TDatabase>,
        InsertEntity<TDatabase, TEntity>,
        InsertEntities<TDatabase, TEntity>,
        InsertEntityTermination<TDatabase, TEntity>,
        InsertEntitiesTermination<TDatabase, TEntity>,
        InsertEntityTermination<TDatabase>,
        InsertEntitiesTermination<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        #region internals
        protected IQueryExpressionFactory QueryExpressionFactory { get; private set; }
        protected IQueryExpressionExecutionPipelineFactory ExecutionPipelineFactory { get; private set; }
        private readonly InsertQueryExpression _expression;
        protected IEnumerable<TEntity> Instances = Enumerable.Empty<TEntity>();
        protected override QueryExpression Expression => InsertQueryExpression;
        public InsertQueryExpression InsertQueryExpression => _expression;
        #endregion

        #region constructors
        public InsertQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            IEnumerable<TEntity> instances
        )
        {
            QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
            _expression = queryExpressionFactory.CreateQueryExpression<InsertQueryExpression>();
            Instances = instances;
        }
        #endregion

        #region methods
        #region InsertEntity<TDatabase, TEntity>
        /// <inheritdoc />
        InsertEntityTermination<TDatabase, TEntity> InsertEntity<TDatabase, TEntity>.Into(Table<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        /// <inheritdoc />
        InsertEntitiesTermination<TDatabase, TEntity> InsertEntities<TDatabase, TEntity>.Into(Table<TEntity> entity)
        {
            Into(entity);
            return this;
        }
        #endregion

        private void Into(Table<TEntity> entity)
        {
            var i = 0;
            InsertQueryExpression.Into = entity;
            InsertQueryExpression.Inserts = Instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, (entity.BuildInclusiveInsertExpression(x) as IExpressionListProvider<InsertExpression>).Expressions));
            InsertQueryExpression.Outputs = entity.BuildInclusiveSelectExpression().Expressions.Select(x => x.AsFieldExpression()).Where(x => x is not null).Cast<FieldExpression>().ToList();
        }

        #region InsertEntityTermination<TDatabase>
        /// <inheritdoc />
        void InsertEntityTermination<TDatabase>.Execute()
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void InsertEntityTermination<TDatabase>.Execute(int commandTimeout)
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
        void InsertEntityTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void InsertEntityTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
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
        Task InsertEntityTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task InsertEntityTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task InsertEntityTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task InsertEntityTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }
        #endregion

        #region InsertEntitiesTermination<TDatabase>
        /// <inheritdoc />
        void InsertEntitiesTermination<TDatabase>.Execute()
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        void InsertEntitiesTermination<TDatabase>.Execute(int commandTimeout)
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
        void InsertEntitiesTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        void InsertEntitiesTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
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
        Task InsertEntitiesTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task InsertEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task InsertEntitiesTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }
        
        /// <inheritdoc />
        Task InsertEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!InsertQueryExpression.Inserts.Any())
                return Task.CompletedTask;

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }
        #endregion

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory.CreateInsertQueryExecutionPipeline().ExecuteInsert<TEntity>(InsertQueryExpression, connection, configureCommand);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => ExecutionPipelineFactory.CreateInsertQueryExecutionPipeline().ExecuteInsertAsync<TEntity>(InsertQueryExpression, connection, configureCommand, cancellationToken);
        #endregion
    }
}
