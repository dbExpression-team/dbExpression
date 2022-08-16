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
    public class SelectObjectsSelectQueryExpressionBuilder<TObject> : SelectQueryExpressionBuilder,
        SelectObjects<TObject>,
        SelectObjectsContinuation<TObject>,
        WithAlias<SelectObjectsContinuation<TObject>>,
        SelectObjectsOrderByContinuation<TObject>,
        SelectObjectsOffsetContinuation<TObject>,
        UnionSelectObjectsContinuation<TObject>
        where TObject : class?
    {
        #region constructors
        public SelectObjectsSelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder controller
        ) : base(executionPipelineFactory, controller)
        {

        }
        #endregion

        #region methods
        #region UnionSelectObjectsInitiation<TObject>
        UnionSelectObjectsContinuation<TObject> UnionSelectObjectsInitiation<TObject>.Union()
        {
            Controller.ApplyUnion();
            return this;
        }

        UnionSelectObjectsContinuation<TObject> UnionSelectObjectsInitiation<TObject>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectObjectsContinuation<TObject>
        /// <inheritdoc>
        SelectObjects<TObject> UnionSelectObjectsContinuation<TObject>.SelectOne(ObjectElement<TObject> element)
        {
            var exp = Controller.StartNew();
            exp.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectObjects<TObject> UnionSelectObjectsContinuation<TObject>.SelectMany(ObjectElement<TObject> element)
        {
            Controller.StartNew().Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        #endregion

        #region SelectObjects<TObject>
        /// <inheritdoc />
        SelectObjects<TObject> SelectObjects<TObject>.Top(int Object)
        {
            ApplyTop(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjects<TObject> SelectObjects<TObject>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TObject> SelectObjects<TObject>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectObjectsContinuation<TObject>> SelectObjects<TObject>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectObjectsContinuation<TObject>
        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TObject> SelectObjectsContinuation<TObject>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TObject> SelectObjectsContinuation<TObject>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TObject> SelectObjectsContinuation<TObject>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TObject> SelectObjectsContinuation<TObject>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TObject> SelectObjectsContinuation<TObject>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TObject> SelectObjectsContinuation<TObject>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TObject>> SelectObjectsContinuation<TObject>.InnerJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TObject>>> SelectObjectsContinuation<TObject>.InnerJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TObject>> SelectObjectsContinuation<TObject>.LeftJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TObject>>> SelectObjectsContinuation<TObject>.LeftJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TObject>> SelectObjectsContinuation<TObject>.RightJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TObject>>> SelectObjectsContinuation<TObject>.RightJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TObject>> SelectObjectsContinuation<TObject>.FullJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectsContinuation<TObject>>> SelectObjectsContinuation<TObject>.FullJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectObjectsContinuation<TObject> SelectObjectsContinuation<TObject>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TObject> WithAlias<SelectObjectsContinuation<TObject>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectObjectsOrderByContinuation<TObject>
        /// <inheritdoc />
        SelectObjectsOffsetContinuation<TObject> SelectObjectsOrderByContinuation<TObject>.Offset(int Object)
        {
            ApplyOffset(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TObject> Limit<SelectObjectsOrderByContinuation<TObject>>.Limit(int Object)
        {
            ApplyLimit(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TObject> SelectObjectsOrderByContinuation<TObject>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TObject> SelectObjectsOrderByContinuation<TObject>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TObject> SelectObjectsOrderByContinuation<TObject>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectObjectsOffsetContinuation<TObject>
        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TObject> Limit<SelectObjectsOrderByContinuation<TObject>>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectObjectsTermination<TObject>
        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TObject>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TObject>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TObject>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TObject>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TObject>.Execute(Action<TObject?> read)
        {
            ExecutePipeline(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TObject>.Execute(int commandTimeout, Action<TObject?> read)
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
        void SelectObjectsTermination<TObject>.Execute(ISqlConnection connection, Action<TObject?> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TObject>.Execute(ISqlConnection connection, int commandTimeout, Action<TObject?> read)
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
        async Task<IList<TObject>> SelectObjectsTermination<TObject>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(Action<TObject?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(ISqlConnection connection, Action<TObject?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(ISqlConnection connection, Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual IList<TObject> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => Controller.CreateExecutionPipeline().ExecuteSelectValueList<TObject>(Controller.SelectSetQueryExpression, connection, configureCommand);

        protected virtual async Task<IList<TObject>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectValueListAsync<TObject>(Controller.SelectSetQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TObject?> read)
            => Controller.CreateExecutionPipeline().ExecuteSelectValueList<TObject>(Controller.SelectSetQueryExpression, connection, configureCommand, read);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TObject?> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectValueListAsync<TObject>(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<TObject?, Task> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectValueListAsync<TObject>(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
