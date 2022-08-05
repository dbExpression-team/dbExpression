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
            ISqlDatabaseRuntime database,
            Func<ISelectQueryExecutionPipeline<TDatabase>> executionPipelineFactory,
            SelectSetQueryExpressionBuilder<TDatabase> controller
        ) : base(database, executionPipelineFactory, controller)
        {

        }
        #endregion

        #region methods
        #region UnionSelectDynamicsInitiation<TDatabase>
        UnionSelectDynamicsContinuation<TDatabase> UnionSelectDynamicsInitiation<TDatabase>.Union()
        {
            Controller.ApplyUnion();
            return this;
        }

        UnionSelectDynamicsContinuation<TDatabase> UnionSelectDynamicsInitiation<TDatabase>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectDynamicsContinuation<TDatabase>
        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements)
        {
            var exp = Controller.StartNew();
            exp.Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)))));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            var exp = Controller.StartNew();
            exp.Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression(Database.MetadataProvider))));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            var exp = Controller.StartNew();
            exp.Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectMany(IEnumerable<AnyElement> elements)
        {
            Controller.StartNew().Select = new(new List<SelectExpression>(elements.Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element)))));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
        {
            Controller.StartNew().Select = new(new List<SelectExpression>(elements.Length + 2)
            {
                element1?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element1)),
                element2?.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element2))
            }.Concat(elements.Select(x => x.ToSelectExpression(Database.MetadataProvider))));
            return this;
        }

        /// <inheritdoc>
        SelectDynamics<TDatabase> UnionSelectDynamicsContinuation<TDatabase>.SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
        {
            Controller.StartNew().Select = new(elements.Concat(additionalElements).Select(element => element.ToSelectExpression(Database.MetadataProvider) ?? throw new ArgumentNullException(nameof(element))));
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
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
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
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.LeftJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.RightJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.FullJoin(AnyEntity entity)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectDynamicsContinuation<TDatabase>>> SelectDynamicsContinuation<TDatabase>.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinExpressionBuilder<TDatabase>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> WithAlias<SelectDynamicsContinuation<TDatabase>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.GroupBy(params AnyGroupByExpression[] groupBy)
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
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
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
            using var connection = Database.GetConnection();
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            return ExecutePipeline(
                connection,
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
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(Func<ISqlFieldReader, T> map)
        {
            using var connection = Database.GetConnection();
            return ExecutePipeline<T>(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(int commandTimeout, Func<ISqlFieldReader, T> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            return ExecutePipeline(
                connection,
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
            using var connection = Database.GetConnection();
            ExecutePipeline(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination<TDatabase>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            ExecutePipeline(
                connection,
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
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            return await ExecutePipelineAsync(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            await ExecutePipelineAsync(
                connection,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            await ExecutePipelineAsync(
                connection,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        protected virtual IList<dynamic> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => Controller.CreateExecutionPipeline().ExecuteSelectDynamicList(Controller.SelectSetQueryExpression, connection, configureCommand);

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => Controller.CreateExecutionPipeline().ExecuteSelectDynamicList(Controller.SelectSetQueryExpression, connection, configureCommand, read);

        protected virtual IList<T> ExecutePipeline<T>(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> map)
            => Controller.CreateExecutionPipeline().ExecuteSelectObjectList(Controller.SelectSetQueryExpression, connection, configureCommand, map);

        protected virtual async Task<IList<dynamic>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectDynamicListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectDynamicListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectDynamicListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<T>> ExecutePipelineAsync<T>(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectObjectListAsync(Controller.SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
        #endregion
    }
}
