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
    public class SelectEntitySelectQueryExpressionBuilder<TDatabase, TEntity> : SelectQueryExpressionBuilder<TDatabase>,
        SelectEntity<TDatabase, TEntity>,
        SelectEntityContinuation<TDatabase, TEntity>,
        WithAlias<SelectEntityContinuation<TDatabase, TEntity>>,
        UnionSelectEntitiesInitiation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Table<TEntity> table;
        #endregion

        #region constructors
        public SelectEntitySelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
            Table<TEntity> table
        ) : base(queryExpressionFactory, executionPipelineFactory)
        {
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public SelectEntitySelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
            Table<TEntity> table,
            SelectQueryExpression rootExpression,
            SelectQueryExpression currentExpression
        ) : base(queryExpressionFactory, executionPipelineFactory, rootExpression, currentExpression)
        {
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }
        #endregion

        #region methods
        #region UnionSelectEntitiesInitiation<TDatabase>
        UnionSelectEntitiesContinuation<TDatabase, TEntity> UnionSelectEntitiesInitiation<TDatabase, TEntity>.Union()
        {
            ApplyUnion();
            Current.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionException($"Select expressions for entity {typeof(TEntity)} were not provided.");
            return new SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                table,
                SelectQueryExpression,
                Current
            );
        }

        UnionSelectEntitiesContinuation<TDatabase, TEntity> UnionSelectEntitiesInitiation<TDatabase, TEntity>.UnionAll()
        {
            ApplyUnionAll();
            Current.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionException($"Select expressions for entity {typeof(TEntity)} were not provided.");
            return new SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                table,
                SelectQueryExpression,
                Current
            );
        }
        #endregion

        #region SelectEntity<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntity<TDatabase, TEntity>.From<TFrom>(Table<TFrom> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectEntityContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.OrderBy(IEnumerable<AnyOrderByExpression> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByExpression> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.Having(AnyHavingExpression having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.Where(AnyWhereExpression where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> SelectEntityContinuation<TDatabase, TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> SelectEntityContinuation<TDatabase, TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> SelectEntityContinuation<TDatabase, TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> SelectEntityContinuation<TDatabase, TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this); 

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> WithAlias<SelectEntityContinuation<TDatabase, TEntity>>.As(string alias)
        {
            Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectEntityTermination<TDatabase, TEntity>
        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        private TEntity? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Current, table, connection, configureCommand);

        private TEntity? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Current, table, connection, configureCommand, map);

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Current, table, connection, configureCommand, read);

        private TEntity? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Current, table, connection, configureCommand, map);

        private Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Current, table, connection, configureCommand, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Current, table, connection, configureCommand, read, cancellationToken);

        private Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Current, table, connection, configureCommand, map, cancellationToken);

        private Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Current, table, connection, configureCommand, map, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Current, table, connection, configureCommand, read, cancellationToken);

        private Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Current, table, connection, configureCommand, map, cancellationToken);
        #endregion
        #endregion
    }
}
