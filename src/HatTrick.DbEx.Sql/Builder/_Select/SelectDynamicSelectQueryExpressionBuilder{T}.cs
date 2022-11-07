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
    public class SelectDynamicSelectQueryExpressionBuilder<TDatabase> : SelectQueryExpressionBuilder<TDatabase>,
        SelectDynamic<TDatabase>,
        SelectDynamicContinuation<TDatabase>,
        WithAlias<SelectDynamicContinuation<TDatabase>>,
        UnionSelectDynamicsInitiation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region constructors
        public SelectDynamicSelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory
        ) : base(queryExpressionFactory, executionPipelineFactory)
        {

        }

        public SelectDynamicSelectQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
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
            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        UnionSelectDynamicsContinuation<TDatabase> UnionSelectDynamicsInitiation<TDatabase>.UnionAll()
        {
            ApplyUnionAll();
            return new SelectDynamicsSelectQueryExpressionBuilder<TDatabase>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }
        #endregion

        #region SelectDynamic
        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamic<TDatabase>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectDynamicContinuation<TDatabase>> SelectDynamic<TDatabase>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectDynamicContinuation
        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.OrderBy(params OrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.OrderBy(IEnumerable<AnyOrderByExpression> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.OrderBy(IEnumerable<OrderByExpression> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.Where(AnyWhereExpression where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.InnerJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> SelectDynamicContinuation<TDatabase>.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this); 

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.LeftJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> SelectDynamicContinuation<TDatabase>.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.RightJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> SelectDynamicContinuation<TDatabase>.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.FullJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> SelectDynamicContinuation<TDatabase>.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder<TDatabase>(Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> WithAlias<SelectDynamicContinuation<TDatabase>>.As(string alias)
        {
            Current.From!.As(alias);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.GroupBy(params GroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.GroupBy(IEnumerable<AnyGroupByExpression> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.GroupBy(IEnumerable<GroupByExpression> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.Having(AnyHavingExpression having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicTermination
        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(Func<ISqlFieldReader, dynamic> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(int commandTimeout, Func<ISqlFieldReader, dynamic> map)
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
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map)
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
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        void SelectDynamicTermination<TDatabase>.Execute(Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectDynamicTermination<TDatabase>.Execute(int commandTimeout, Action<ISqlFieldReader> read)
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
        void SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
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
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
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
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
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
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
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

        private dynamic? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectDynamic(Current, connection, configureCommand);

        private dynamic? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, dynamic> map)
            => ExecutionPipelineFactory().ExecuteSelectObject(Current, connection, configureCommand, map);

        private void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => ExecutionPipelineFactory().ExecuteSelectDynamic(Current, connection, configureCommand, read);

        private T? ExecutPipeline<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> map)
            => ExecutionPipelineFactory().ExecuteSelectObject(Current, connection, configureCommand, map);

        private Task<dynamic?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectDynamicAsync(Current, connection, configureCommand, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectDynamicAsync(Current, connection, configureCommand, read, cancellationToken);

        private Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectDynamicAsync(Current, connection, configureCommand, read, cancellationToken);

        private Task<dynamic?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteSelectObjectAsync(Current, connection, configureCommand, map, cancellationToken);
        #endregion
        #endregion
    }
}
