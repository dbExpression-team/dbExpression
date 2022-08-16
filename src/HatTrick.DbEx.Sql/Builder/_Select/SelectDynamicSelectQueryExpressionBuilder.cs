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
    public class SelectDynamicSelectQueryExpressionBuilder : SelectQueryExpressionBuilder,
        SelectDynamic,
        SelectDynamicContinuation,
        WithAlias<SelectDynamicContinuation>,
        UnionSelectDynamicsInitiation
    {
        #region constructors
        public SelectDynamicSelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder controller
        ) : base(executionPipelineFactory, controller)
        {

        }
        #endregion

        #region methods
        #region UnionSelectDynamicsInitiation
        UnionSelectDynamicsContinuation UnionSelectDynamicsInitiation.Union()
        {
            Controller.ApplyUnion();
            return new SelectDynamicsSelectQueryExpressionBuilder(
                ExecutionPipelineFactory,
                Controller
            );
        }

        UnionSelectDynamicsContinuation UnionSelectDynamicsInitiation.UnionAll()
        {
            Controller.ApplyUnionAll();
            return new SelectDynamicsSelectQueryExpressionBuilder(
                ExecutionPipelineFactory,
                Controller
            );
        }
        #endregion

        #region SelectDynamic
        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamic.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectDynamicContinuation> SelectDynamic.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectDynamicContinuation
        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamicContinuation.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamicContinuation.OrderBy(IEnumerable<AnyOrderByExpression> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamicContinuation.Where(AnyWhereExpression where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.InnerJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation>> SelectDynamicContinuation.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this); 

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.LeftJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation>> SelectDynamicContinuation.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.RightJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation>> SelectDynamicContinuation.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.FullJoin(AnyEntity entity)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicContinuation>> SelectDynamicContinuation.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamicContinuation.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation WithAlias<SelectDynamicContinuation>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamicContinuation.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamicContinuation.GroupBy(IEnumerable<AnyGroupByExpression> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation SelectDynamicContinuation.Having(AnyHavingExpression having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicTermination
        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute(Func<ISqlFieldReader, dynamic> map)
        {
            return ExecutePipeline(
                null,
                null,
                map
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute(int commandTimeout, Func<ISqlFieldReader, dynamic> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                map
            );
        }

        /// <inheritdoc />
        dynamic? SelectDynamicTermination.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map
            );
        }

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        void SelectDynamicTermination.Execute(Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectDynamicTermination.Execute(int commandTimeout, Action<ISqlFieldReader> read)
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
        void SelectDynamicTermination.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectDynamicTermination.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        async Task SelectDynamicTermination.ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicTermination.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicTermination.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicTermination.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task<dynamic?> SelectDynamicTermination.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual dynamic? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectDynamic(Controller.Current, connection, configureCommand);

        protected virtual dynamic? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, dynamic> map)
            => ExecutionPipelineFactory().ExecuteSelectObject(Controller.Current, connection, configureCommand, map);

        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => ExecutionPipelineFactory().ExecuteSelectDynamic(Controller.Current, connection, configureCommand, read);

        protected virtual T? ExecutPipeline<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> map)
            => ExecutionPipelineFactory().ExecuteSelectObject(Controller.Current, connection, configureCommand, map);

        protected virtual async Task<dynamic?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectDynamicAsync(Controller.Current, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectDynamicAsync(Controller.Current, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectDynamicAsync(Controller.Current, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<dynamic?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectObjectAsync(Controller.Current, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
