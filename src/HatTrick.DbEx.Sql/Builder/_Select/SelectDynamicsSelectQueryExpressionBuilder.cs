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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectDynamicsSelectQueryExpressionBuilder : SelectQueryExpressionBuilder,
        SelectDynamics,
        SelectDynamicsContinuation,
        WithAlias<SelectDynamicsContinuation>,
        SelectDynamicsOrderByContinuation,
        SelectDynamicsOffsetContinuation,
        UnionSelectDynamicsContinuation
    {
        #region constructors
        public SelectDynamicsSelectQueryExpressionBuilder(
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
            return this;
        }

        UnionSelectDynamicsContinuation UnionSelectDynamicsInitiation.UnionAll()
        {
            Controller.ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectDynamicsContinuation
        /// <inheritdoc>
        SelectDynamics UnionSelectDynamicsContinuation.SelectOne(IEnumerable<AnyElement> elements)
        {
            var exp = Controller.StartNew();
            exp.Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)))));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectDynamics UnionSelectDynamicsContinuation.SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            var exp = Controller.StartNew();
            exp.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectDynamics UnionSelectDynamicsContinuation.SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            var exp = Controller.StartNew();
            exp.Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectDynamics UnionSelectDynamicsContinuation.SelectMany(IEnumerable<AnyElement> elements)
        {
            Controller.StartNew().Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)))));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics UnionSelectDynamicsContinuation.SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            Controller.StartNew().Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression())));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics UnionSelectDynamicsContinuation.SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            Controller.StartNew().Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element))));
            return this;
        }
        #endregion

        #region SelectDynamics
        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamics.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectDynamicsContinuation> SelectDynamics.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics SelectDynamics.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics SelectDynamics.Distinct()
        {
            ApplyDistinct();
            return this;
        }
        #endregion

        #region SelectDynamicsContinuation
        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsContinuation.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsContinuation.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.InnerJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation>> SelectDynamicsContinuation.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.LeftJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation>> SelectDynamicsContinuation.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.RightJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation>> SelectDynamicsContinuation.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.FullJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation>> SelectDynamicsContinuation.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation WithAlias<SelectDynamicsContinuation>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion
        
        #region SelectDynamicsOrderByContinuation
        /// <inheritdoc />
        SelectDynamicsOffsetContinuation SelectDynamicsOrderByContinuation.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicsOffsetContinuation
        /// <inheritdoc />
        SelectDynamicsOrderByContinuation Limit<SelectDynamicsOrderByContinuation>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation Limit<SelectDynamicsOrderByContinuation>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }
        #endregion

        #region SelectDynamicsTermination
        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        IList<T> SelectDynamicsTermination.Execute<T>(Func<ISqlFieldReader, T> map)
        {
            return ExecutePipeline<T>(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination.Execute<T>(int commandTimeout, Func<ISqlFieldReader, T> map)
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
        IList<T> SelectDynamicsTermination.Execute<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination.Execute<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map)
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
        void SelectDynamicsTermination.Execute(Action<ISqlFieldReader> map)
        {
            ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination.Execute(int commandTimeout, Action<ISqlFieldReader> map)
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
        void SelectDynamicsTermination.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
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

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync<T>(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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

        #region execute pipeline
        protected virtual IList<dynamic> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => Controller.CreateExecutionPipeline().ExecuteSelectDynamicList(Controller.SelectSetQueryExpression, connection, configureCommand);

        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => Controller.CreateExecutionPipeline().ExecuteSelectDynamicList(Controller.SelectSetQueryExpression, connection, configureCommand, read);

        protected virtual IList<T> ExecutePipeline<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> map)
            => Controller.CreateExecutionPipeline().ExecuteSelectObjectList(Controller.SelectSetQueryExpression, connection, configureCommand, map);

        protected virtual async Task<IList<dynamic>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectDynamicListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectDynamicListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectDynamicListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<T>> ExecutePipelineAsync<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectObjectListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
        #endregion
    }
}
