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
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity> : SelectQueryExpressionBuilder<TDatabase>,
        SelectEntities<TDatabase, TEntity>,
        SelectEntitiesContinuation<TDatabase, TEntity>,
        WithAlias<SelectEntitiesContinuation<TDatabase, TEntity>>,
        SelectEntitiesOrderByContinuation<TDatabase, TEntity>,
        SelectEntitiesOffsetContinuation<TDatabase, TEntity>,
        UnionSelectEntitiesContinuation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Table<TEntity> table;
        #endregion

        #region constructors
        public SelectEntitiesSelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
            Table<TEntity> table
        ) : base(queryExpressionFactory, executionPipelineFactory)
        {
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public SelectEntitiesSelectQueryExpressionBuilder(
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
        #region UnionSelectEntitiesInitiation<TDatabase, TEntity>
        UnionSelectEntitiesContinuation<TDatabase, TEntity> UnionSelectEntitiesInitiation<TDatabase, TEntity>.Union()
        {
            ApplyUnion();
            Current.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionQueryException(Expression, ExceptionMessages.NullValueUnexpected());
            return this;
        }

        UnionSelectEntitiesContinuation<TDatabase, TEntity> UnionSelectEntitiesInitiation<TDatabase, TEntity>.UnionAll()
        {
            ApplyUnionAll();
            Current.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionQueryException(Expression, ExceptionMessages.NullValueUnexpected());
            return this;
        }
        #endregion

        #region UnionSelectValuesContinuation<TDatabase, TValue>
        /// <inheritdoc>
        SelectEntities<TDatabase, TEntity> UnionSelectEntitiesContinuation<TDatabase, TEntity>.SelectOne()
        {
            ApplyTop(1);
            Current.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionQueryException(Expression, ExceptionMessages.NullValueUnexpected());
            return this;
        }

        /// <inheritdoc>
        SelectEntities<TDatabase, TEntity> UnionSelectEntitiesContinuation<TDatabase, TEntity>.SelectMany()
        {
            Current.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionQueryException(Expression, ExceptionMessages.NullValueUnexpected());
            return this;
        }
        #endregion

        #region SelectEntities<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntities<TDatabase, TEntity> SelectEntities<TDatabase, TEntity>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectEntities<TDatabase, TEntity> SelectEntities<TDatabase, TEntity>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntities<TDatabase, TEntity>.From<TFrom>(Table<TFrom> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectEntitiesContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(params OrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(IEnumerable<OrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(params GroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<GroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> WithAlias<SelectEntitiesContinuation<TDatabase, TEntity>>.As(string alias)
        {
            Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectEntitiesOrderByContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntitiesOffsetContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(params GroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<GroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> Limit<SelectEntitiesOrderByContinuation<TDatabase, TEntity>>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectEntitiesOffsetContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> Limit<SelectEntitiesOrderByContinuation<TDatabase, TEntity>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }
        #endregion

        #region SelectEntitiesTermination<TDatabase, TEntity>
        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
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
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
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
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader> map)
        {
            ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
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
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
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
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
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
        IAsyncEnumerable<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        #region execute pipeline
        private IList<TEntity> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(SelectQueryExpression, table, connection, configureCommand);

        private IList<TEntity> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map)
            => CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(SelectQueryExpression, table, connection, configureCommand, map);

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(SelectQueryExpression, table, connection, configureCommand, read);

        private IList<TEntity> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            => CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(SelectQueryExpression, table, connection, configureCommand, map);

        private Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression, table, connection, configureCommand, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression, table, connection, configureCommand, read, cancellationToken);

        private Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression, table, connection, configureCommand, map, cancellationToken);

        private Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression, table, connection, configureCommand, map, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression, table, connection, configureCommand, map, cancellationToken);

        private Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression, table, connection, configureCommand, map, cancellationToken);

        private IAsyncEnumerable<TEntity> ExecutePipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression, table, connection, configureCommand, cancellationToken);

        private IAsyncEnumerable<TEntity> ExecutePipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression, table, connection, configureCommand, map, cancellationToken);

        private IAsyncEnumerable<TEntity> ExecutePipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression, table, connection, configureCommand, map, cancellationToken);

        private IAsyncEnumerable<TEntity> ExecutePipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression, table, connection, configureCommand, map, cancellationToken);
        #endregion
        #endregion
        #endregion
    }
}
