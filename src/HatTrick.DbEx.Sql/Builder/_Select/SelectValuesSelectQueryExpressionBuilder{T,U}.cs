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
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory
        ) : base(queryExpressionFactory, executionPipelineFactory)
        {

        }

        public SelectValuesSelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
            SelectQueryExpression rootExpression,
            SelectQueryExpression currentExpression
        ) : base(queryExpressionFactory, executionPipelineFactory, rootExpression, currentExpression)
        {

        }
        #endregion

        #region methods
        #region UnionSelectValuesInitiation<TDatabase, TValue>
        UnionSelectValuesContinuation<TDatabase, TValue> UnionSelectValuesInitiation<TDatabase, TValue>.Union()
        {
            ApplyUnion();
            return this;
        }

        UnionSelectValuesContinuation<TDatabase, TValue> UnionSelectValuesInitiation<TDatabase, TValue>.UnionAll()
        {
            ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectValuesContinuation<TDatabase, TValue>
        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectOne(AnyElement<TValue> element)
        {
            ApplyTop(1);
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectOne(StringElement element)
        {
            ApplyTop(1);
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectOne(NullableStringElement element)
        {
            ApplyTop(1);
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectMany(AnyElement<TValue> element)
        {
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectMany(StringElement element)
        {
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
            return this;
        }

        /// <inheritdoc>
        SelectValues<TDatabase, TValue> UnionSelectValuesContinuation<TDatabase, TValue>.SelectMany(NullableStringElement element)
        {
            Current.Select = new(element?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
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
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.LeftJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.RightJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.FullJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValuesContinuation<TDatabase, TValue>>> SelectValuesContinuation<TDatabase, TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> WithAlias<SelectValuesContinuation<TDatabase, TValue>>.As(string alias)
        {
            Current.From!.As(alias);
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
        Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Action<TValue?> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
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
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Action<TValue?> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
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
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
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
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
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

        private IList<TValue> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectValueList<TValue>(SelectQueryExpression, connection, configureCommand);

        private Task<IList<TValue>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectValueListAsync<TValue>(SelectQueryExpression, connection, configureCommand, cancellationToken);

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TValue?> read)
            => CreateExecutionPipeline().ExecuteSelectValueList<TValue>(SelectQueryExpression, connection, configureCommand, read);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<TValue?> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectValueListAsync<TValue>(SelectQueryExpression, connection, configureCommand, read, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<TValue?, Task> read, CancellationToken cancellationToken)
            => CreateExecutionPipeline().ExecuteSelectValueListAsync<TValue>(SelectQueryExpression, connection, configureCommand, read, cancellationToken);
        #endregion
        #endregion
    }
}
