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
        private readonly IEnumerable<TEntity> instances;
        protected InsertQueryExpression Expression { get; private set; }
        #endregion

        #region constructors
        public InsertQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<TEntity> instances, InsertQueryExpression expression) : base(configuration, expression)
        {
            Expression = expression;
            this.instances = instances;
        }
        #endregion

        #region methods
        /// <inheritdoc />
        InsertEntityTermination<TEntity> InsertEntity<TEntity>.Into(Entity<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        /// <inheritdoc />
        InsertEntitiesTermination<TEntity> InsertEntities<TEntity>.Into(Entity<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        protected virtual void Into(Entity<TEntity> entity)
        {
            var i = 0;
            var insertEntity = entity as IEntityExpression<TEntity> ?? throw new InvalidOperationException($"Expected {nameof(entity)} to be of type {typeof(IEntityExpression<TEntity>)}.");
            Expression.BaseEntity = entity as EntityExpression<TEntity> ?? throw new InvalidOperationException($"Expected {nameof(entity)} to be of type {typeof(EntityExpression<TEntity>)}");
            Expression.Inserts = instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, (insertEntity.BuildInclusiveInsertExpression(x) as IExpressionListProvider<InsertExpression>).Expressions));
            Expression.Outputs = insertEntity.BuildInclusiveSelectExpression().Expressions.Select(x => x.AsFieldExpression()).Where(x => x is not null).Cast<FieldExpression>().ToList();
        }

        #region InsertEntityTerminationExpressionBuilder
        /// <inheritdoc />
        void InsertEntityTermination.Execute()
        {
            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        void InsertEntityTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void InsertEntityTermination.Execute(ISqlConnection connection)
        {
            if (!Expression.Inserts.Any())
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

            if (!Expression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task InsertEntityTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntityTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            if (!Expression.Inserts.Any())
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

            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntityTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!Expression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region InsertEntitiesTerminationExpressionBuilder
        /// <inheritdoc />
        void InsertEntitiesTermination.Execute()
        {
            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        void InsertEntitiesTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void InsertEntitiesTermination.Execute(ISqlConnection connection)
        {
            if (!Expression.Inserts.Any())
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

            if (!Expression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task InsertEntitiesTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task InsertEntitiesTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            if (!Expression.Inserts.Any())
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

            if (!Expression.Inserts.Any())
                return;

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        async Task InsertEntitiesTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            if (!Expression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        #endregion
        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateInsertExecutionPipeline().ExecuteInsert(Expression, connection, configureCommand);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await CreateInsertExecutionPipeline().ExecuteInsertAsync(Expression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual IInsertQueryExpressionExecutionPipeline CreateInsertExecutionPipeline()
        {
            return Configuration.ExecutionPipelineFactory.CreateQueryExecutionPipeline<TEntity>(Configuration, Expression);
        }
        #endregion
    }
}
