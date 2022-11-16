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
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject> : SelectQueryExpressionBuilder<TDatabase>,
        SelectObjects<TDatabase, TObject>,
        SelectObjectsContinuation<TDatabase, TObject>,
        WithAlias<SelectObjectsContinuation<TDatabase, TObject>>,
        SelectObjectsOrderByContinuation<TDatabase, TObject>,
        SelectObjectsOffsetContinuation<TDatabase, TObject>,
        UnionSelectObjectsContinuation<TDatabase, TObject>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        #region constructors
        public SelectObjectsSelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
            SelectQueryExpression rootExpression,
            SelectQueryExpression currentExpression
        ) : base(queryExpressionFactory, executionPipelineFactory, rootExpression, currentExpression)
        {

        }
        #endregion

        #region methods
        #region UnionSelectObjectsInitiation<TDatabase, TObject>
        UnionSelectObjectsContinuation<TDatabase, TObject> UnionSelectObjectsInitiation<TDatabase, TObject>.Union()
        {
            ApplyUnion();
            return this;
        }

        UnionSelectObjectsContinuation<TDatabase, TObject> UnionSelectObjectsInitiation<TDatabase, TObject>.UnionAll()
        {
            ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectObjectsContinuation<TDatabase, TObject>
        /// <inheritdoc>
        SelectObjects<TDatabase, TObject> UnionSelectObjectsContinuation<TDatabase, TObject>.SelectOne(ObjectElement<TObject> element)
        {
            ApplyTop(1);
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectObjects<TDatabase, TObject> UnionSelectObjectsContinuation<TDatabase, TObject>.SelectMany(ObjectElement<TObject> element)
        {
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        #endregion

        #region SelectObjects<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjects<TDatabase, TObject> SelectObjects<TDatabase, TObject>.Top(int Object)
        {
            ApplyTop(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjects<TDatabase, TObject> SelectObjects<TDatabase, TObject>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjects<TDatabase, TObject>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectObjectsContinuation<TDatabase, TObject>> SelectObjects<TDatabase, TObject>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectObjectsContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.InnerJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TDatabase, TObject>>> SelectObjectsContinuation<TDatabase, TObject>.InnerJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.LeftJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TDatabase, TObject>>> SelectObjectsContinuation<TDatabase, TObject>.LeftJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.RightJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TDatabase, TObject>>> SelectObjectsContinuation<TDatabase, TObject>.RightJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.FullJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TDatabase, TObject>>> SelectObjectsContinuation<TDatabase, TObject>.FullJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> WithAlias<SelectObjectsContinuation<TDatabase, TObject>>.As(string alias)
        {
            Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectObjectsOrderByContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectsOffsetContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.Offset(int Object)
        {
            ApplyOffset(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> Limit<SelectObjectsOrderByContinuation<TDatabase, TObject>>.Limit(int Object)
        {
            ApplyLimit(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectObjectsOffsetContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> Limit<SelectObjectsOrderByContinuation<TDatabase, TObject>>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectObjectsTermination<TObject>
        /// <inheritdoc />
        IEnumerable<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IEnumerable<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IEnumerable<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IEnumerable<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(Action<TObject?> read)
        {
            ExecutePipeline(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(int commandTimeout, Action<TObject?> read)
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
        void SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, Action<TObject?> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout, Action<TObject?> read)
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
        Task<IEnumerable<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IEnumerable<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task<IEnumerable<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IEnumerable<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(Action<TObject?> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
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
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, Action<TObject?> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
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
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
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
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
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

        private IEnumerable<TObject> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectValueList<TObject>(SelectQueryExpression, connection, configureCommand);

        private Task<IEnumerable<TObject>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectValueListAsync<TObject>(SelectQueryExpression, connection, configureCommand, cancellationToken);

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TObject?> read)
            => CreateExecutionPipeline().ExecuteSelectValueList<TObject>(SelectQueryExpression, connection, configureCommand, read);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TObject?> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectValueListAsync<TObject>(SelectQueryExpression, connection, configureCommand, read, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<TObject?, Task> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectValueListAsync<TObject>(SelectQueryExpression, connection, configureCommand, read, cancellationToken);
        #endregion
        #endregion
    }
}
