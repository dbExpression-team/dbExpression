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

using HatTrick.DbEx.Sql.Pipeline;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using HatTrick.DbEx.Sql.Connection;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValuesSelectQueryExpressionBuilder<TValue> : SelectQueryExpressionBuilder,
        SelectValues<TValue>,
        SelectValuesContinuation<TValue>,
        WithAlias<SelectValuesContinuation<TValue>>,
        SelectValuesOrderByContinuation<TValue>,
        SelectValuesOffsetContinuation<TValue>,
        UnionSelectValuesContinuation<TValue>
    {
        #region constructors
        public SelectValuesSelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder controller //name the type something better
        ) : base(executionPipelineFactory, controller)
        {

        }
        #endregion

        #region methods
        #region UnionSelectValuesInitiation<TValue>
        UnionSelectValuesContinuation<TValue> UnionSelectValuesInitiation<TValue>.Union()
        {
            Controller.ApplyUnion();
            return this;
        }

        UnionSelectValuesContinuation<TValue> UnionSelectValuesInitiation<TValue>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectValuesContinuation<TValue>
        /// <inheritdoc>
        SelectValues<TValue> UnionSelectValuesContinuation<TValue>.SelectOne(AnyElement<TValue> element)
        {
            var exp = Controller.StartNew();
            exp.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectValues<TValue> UnionSelectValuesContinuation<TValue>.SelectOne(StringElement element)
        {
            var exp = Controller.StartNew();
            exp.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectValues<TValue> UnionSelectValuesContinuation<TValue>.SelectOne(NullableStringElement element)
        {
            var exp = Controller.StartNew();
            exp.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectValues<TValue> UnionSelectValuesContinuation<TValue>.SelectMany(AnyElement<TValue> element)
        {
            Controller.StartNew().Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TValue> UnionSelectValuesContinuation<TValue>.SelectMany(StringElement element)
        {
            Controller.StartNew().Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TValue> UnionSelectValuesContinuation<TValue>.SelectMany(NullableStringElement element)
        {
            Controller.StartNew().Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }
        #endregion

        #region SelectValues<TValue>
        /// <inheritdoc />
        SelectValues<TValue> SelectValues<TValue>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectValues<TValue> SelectValues<TValue>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValues<TValue>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectValuesContinuation<TValue>> SelectValues<TValue>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectValuesContinuation<TValue>
        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesContinuation<TValue>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesContinuation<TValue>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.InnerJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TValue>>> SelectValuesContinuation<TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.LeftJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TValue>>> SelectValuesContinuation<TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.RightJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TValue>>> SelectValuesContinuation<TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.FullJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TValue>>> SelectValuesContinuation<TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> WithAlias<SelectValuesContinuation<TValue>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectValuesOrderByContinuation<TValue>
        /// <inheritdoc />
        SelectValuesOffsetContinuation<TValue> SelectValuesOrderByContinuation<TValue>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> Limit<SelectValuesOrderByContinuation<TValue>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesOrderByContinuation<TValue>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesOrderByContinuation<TValue>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesOrderByContinuation<TValue>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectValuesOffsetContinuation<TValue>
        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> Limit<SelectValuesOrderByContinuation<TValue>>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectValuesTermination<TValue>
        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TValue>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TValue>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TValue>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(Action<TValue?> handleValue)
        {
            ExecutePipeline(
                null,
                null,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(int commandTimeout, Action<TValue?> handleValue)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(ISqlConnection connection, Action<TValue?> handleValue)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(ISqlConnection connection, int commandTimeout, Action<TValue?> handleValue)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(Action<TValue?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TValue>.ExecuteAsync(int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, Action<TValue?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TValue>.ExecuteAsync(int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
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

        protected virtual IList<TValue> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => Controller.CreateExecutionPipeline().ExecuteSelectValueList<TValue>(Controller.SelectSetQueryExpression, connection, configureCommand);

        protected virtual async Task<IList<TValue>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectValueListAsync<TValue>(Controller.SelectSetQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TValue?> read)
            => Controller.CreateExecutionPipeline().ExecuteSelectValueList<TValue>(Controller.SelectSetQueryExpression, connection, configureCommand, read);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TValue?> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectValueListAsync<TValue>(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<TValue?, Task> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectValueListAsync<TValue>(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
