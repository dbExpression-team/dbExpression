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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Builder
{
    public class SelectDynamicsSelectQueryExpressionBuilder<TDatabase> : SelectQueryExpressionBuilder<TDatabase>,
        SelectDynamics<TDatabase>,
        SelectDynamicsContinuation<TDatabase>,
        WithAlias<SelectDynamicsContinuation<TDatabase>>,
        SelectDynamicsOrderByContinuation<TDatabase>,
        SelectDynamicsOffsetContinuation<TDatabase>,
        UnionSelectDynamicsContinuation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region constructors
        public SelectDynamicsSelectQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            IEnumerable<AnyElement> elements
        ) : base(queryExpressionFactory, executionPipelineFactory)
        {
            Current.Select = new(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));
        }

        public SelectDynamicsSelectQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            SelectQueryExpression rootExpression,
            SelectQueryExpression currentExpression
        ) : base(queryExpressionFactory, executionPipelineFactory, rootExpression, currentExpression)
        {

        }
        #endregion

        #region methods
        #region UnionSelectDynamicsInitiation<TDatabase>
        UnionSelectDynamicsContinuation<TDatabase> UnionSelectDynamicsInitiation<TDatabase>.Union()
        {
            ApplyUnion();
            return this;
        }

        UnionSelectDynamicsContinuation<TDatabase> UnionSelectDynamicsInitiation<TDatabase>.UnionAll()
        {
            ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectDynamicsContinuation<TDatabase>
        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements)
        {
            ApplyTop(1);
            Current.Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)))));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            ApplyTop(1);
            Current.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            ApplyTop(1);
            Current.Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectMany(IEnumerable<AnyElement> elements)
        {
            Current.Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)))));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            Current.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            Current.Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));
            return this;
        }
        #endregion

        #region SelectDynamics<TDatabase>
        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamics<TDatabase>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectDynamicsContinuation<TDatabase>> SelectDynamics<TDatabase>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics<TDatabase> SelectDynamics<TDatabase>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics<TDatabase> SelectDynamics<TDatabase>.Distinct()
        {
            ApplyDistinct();
            return this;
        }
        #endregion

        #region SelectDynamicsContinuation<TDatabase>
        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.OrderBy(params OrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.OrderBy(IEnumerable<OrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.InnerJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.LeftJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.RightJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.FullJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> WithAlias<SelectDynamicsContinuation<TDatabase>>.As(string alias)
        {
            Current.From!.As(alias);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.GroupBy(params GroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.GroupBy(IEnumerable<GroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion
        
        #region SelectDynamicsOrderByContinuation<TDatabase>
        /// <inheritdoc />
        SelectDynamicsOffsetContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.GroupBy(params GroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.GroupBy(IEnumerable<GroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicsOffsetContinuation<TDatabase>
        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> Limit<SelectDynamicsOrderByContinuation<TDatabase>>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> Limit<SelectDynamicsOrderByContinuation<TDatabase>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }
        #endregion

        #region SelectDynamicsTermination<TDatabase>
        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        IAsyncEnumerable<dynamic> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken)
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
        Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<dynamic> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        IAsyncEnumerable<dynamic> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(Func<ISqlFieldReader, T> map)
        {
            return ExecutePipeline<T>(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(int commandTimeout, Func<ISqlFieldReader, T> map)
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
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map)
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
        void SelectDynamicsTermination<TDatabase>.Execute(Action<ISqlFieldReader> map)
        {
            ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination<TDatabase>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
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
        void SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<T> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
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
        IAsyncEnumerable<T> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
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
        Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<T> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync<T>(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        IAsyncEnumerable<T> SelectDynamicsTermination<TDatabase>.ExecuteAsyncEnumerable<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsyncEnumerable<T>(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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

        #region execute pipeline
        private IList<dynamic> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectDynamicList(SelectQueryExpression, connection, configureCommand);

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => CreateExecutionPipeline().ExecuteSelectDynamicList(SelectQueryExpression, connection, configureCommand, read);

        private IList<T> ExecutePipeline<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> map)
            => CreateExecutionPipeline().ExecuteSelectObjectList(SelectQueryExpression, connection, configureCommand, map);

        private Task<IList<dynamic>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsync(SelectQueryExpression, connection, configureCommand, cancellationToken);

        private IAsyncEnumerable<dynamic> ExecutePipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsyncEnumerable(SelectQueryExpression, connection, configureCommand, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsync(SelectQueryExpression, connection, configureCommand, read, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectDynamicListAsync(SelectQueryExpression, connection, configureCommand, map, cancellationToken);

        private Task<IList<T>> ExecutePipelineAsync<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectObjectListAsync(SelectQueryExpression, connection, configureCommand, read, cancellationToken);

        private IAsyncEnumerable<T> ExecutePipelineAsyncEnumerable<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectObjectListAsyncEnumerable(SelectQueryExpression, connection, configureCommand, read, cancellationToken);
        #endregion
        #endregion
        #endregion
    }
}
