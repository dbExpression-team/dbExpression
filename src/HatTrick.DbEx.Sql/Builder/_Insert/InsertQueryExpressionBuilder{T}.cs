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
    public abstract class InsertQueryExpressionBuilder<TEntity> : QueryExpressionBuilder,
        InsertEntity<TEntity>,
        InsertEntities<TEntity>,
        InsertEntityTermination<TEntity>,
        InsertEntitiesTermination<TEntity>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly InsertQueryExpression expression;
        private readonly IEnumerable<TEntity> instances;
        #endregion

        #region constructors
        protected InsertQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<TEntity> instances, InsertQueryExpression expression) : base(configuration, expression)
        {
            this.expression = expression;
            this.instances = instances;
        }
        #endregion

        #region methods
        InsertEntityTermination<TEntity> InsertEntity<TEntity>.Into(Entity<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        InsertEntitiesTermination<TEntity> InsertEntities<TEntity>.Into(Entity<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        protected virtual void Into(Entity<TEntity> entity)
        {
            var i = 0;
            var insertEntity = entity as IEntityExpression<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression<TEntity>)}.");
            expression.BaseEntity = entity as EntityExpression<TEntity>;
            expression.Inserts = instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, (insertEntity.BuildInclusiveInsertExpression(x) as IExpressionListProvider<InsertExpression>).Expressions));
            expression.Outputs = insertEntity.BuildInclusiveSelectExpression().Expressions.Select(x => x.AsFieldExpression()).ToList();
        }
        #endregion

        #region InsertTerminationExpressionBuilder
        public virtual void Execute()
        {
            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <inheritdoc />
        public virtual void Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <inheritdoc />
        public virtual void Execute(ISqlConnection connection)
        {
            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        public virtual void Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        public virtual async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                await ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual async Task ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual async Task ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                await ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public virtual async Task ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var expression = GetQueryExpression<InsertQueryExpression>();
            if (!expression.Inserts.Any())
                return;

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private void ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand)
            => CreateInsertExecutionPipeline().ExecuteInsert(GetQueryExpression<InsertQueryExpression>(), connection, configureCommand);

        private async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await CreateInsertExecutionPipeline().ExecuteInsertAsync(GetQueryExpression<InsertQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private IInsertQueryExpressionExecutionPipeline<TEntity> CreateInsertExecutionPipeline()
        {
            return Configuration.ExecutionPipelineFactory.CreateExecutionPipeline<TEntity>(Configuration, GetQueryExpression<InsertQueryExpression>());
        }
        #endregion
    }
}
