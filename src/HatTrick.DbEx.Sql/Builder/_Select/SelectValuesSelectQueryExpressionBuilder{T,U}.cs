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
    public class SelectValuesSelectQueryExpressionBuilder<TDatabase, TValue> : SelectQueryExpressionBuilder<TDatabase>,
        SelectValues<TDatabase, TValue>,
        SelectValuesContinuation<TDatabase, TValue>,
        WithAlias<SelectValuesContinuation<TDatabase, TValue>>,
        SelectValuesOrderByContinuation<TDatabase, TValue>,
        SelectValuesOffsetContinuation<TDatabase, TValue>,
        UnionSelectValuesContinuation<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region constructors
        public SelectValuesSelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder<TDatabase> controller //name the type something better
        ) : base(executionPipelineFactory, controller)
        {

        }
        #endregion

        #region methods
        #region UnionSelectValuesInitiation<TDatabase, TValue>
        UnionSelectValuesContinuation<TDatabase, TValue> UnionSelectValuesInitiation<TDatabase, TValue>.Union()
        {
            Controller.ApplyUnion();
            return this;
        }

        UnionSelectValuesContinuation<TDatabase, TValue> UnionSelectValuesInitiation<TDatabase, TValue>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectValuesContinuation<TDatabase, TValue>
        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectOne(AnyElement<TValue> element)
        {
            var exp = Controller.StartNew();
            exp.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectOne(StringElement element)
        {
            var exp = Controller.StartNew();
            exp.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectOne(NullableStringElement element)
        {
            var exp = Controller.StartNew();
            exp.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectMany(AnyElement<TValue> element)
        {
            Controller.StartNew().Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectMany(StringElement element)
        {
            Controller.StartNew().Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectMany(NullableStringElement element)
        {
            Controller.StartNew().Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }
        #endregion

        #region SelectValues<TDatabase, TValue>
        /// <inheritdoc />
        SelectValues<TDatabase, TValue> SelectValues<TDatabase, TValue>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectValues<TDatabase, TValue> SelectValues<TDatabase, TValue>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValues<TDatabase, TValue>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectValuesContinuation<TDatabase, TValue>> SelectValues<TDatabase, TValue>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectValuesContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.InnerJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.LeftJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.RightJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.FullJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> WithAlias<SelectValuesContinuation<TDatabase, TValue>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectValuesOrderByContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValuesOffsetContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> Limit<SelectValuesOrderByContinuation<TDatabase, TValue>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectValuesOffsetContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> Limit<SelectValuesOrderByContinuation<TDatabase, TValue>>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectValuesTermination<TDatabase, TValue>
        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(Action<TValue?> handleValue)
        {
            ExecutePipeline(
                null,
                null,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(int commandTimeout, Action<TValue?> handleValue)
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
        void SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, Action<TValue?> handleValue)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout, Action<TValue?> handleValue)
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
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Action<TValue?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Action<TValue?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
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
