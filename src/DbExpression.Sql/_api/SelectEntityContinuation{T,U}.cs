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

using DbExpression.Sql.Expression;
using System.Collections.Generic;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntityContinuation<TDatabase, TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        UnionSelectEntitiesInitiation<TDatabase, TEntity>,
        SelectEntityTermination<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        /// <summary>
        /// Construct the WHERE clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="where">Any filter predicate of type <see cref="AnyWhereExpression"/>.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> Where(AnyWhereExpression where);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="AnyOrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> OrderBy(params AnyOrderByExpression[] orderBy);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="OrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> OrderBy(params OrderByExpression[] orderBy);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="AnyOrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> OrderBy(IEnumerable<AnyOrderByExpression> orderBy);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="OrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> OrderBy(IEnumerable<OrderByExpression> orderBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> GroupBy(params AnyGroupByExpression[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="GroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> GroupBy(params GroupByExpression[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> GroupBy(IEnumerable<AnyGroupByExpression> groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="GroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> GroupBy(IEnumerable<GroupByExpression> groupBy);

        /// <summary>
        /// Construct the HAVING clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/having">read the docs on HAVING</see>
        /// </para>
        /// </summary>
        /// <param name="having">A list of expressions of type <see cref="AnyHavingExpression"/> specifying conditions on the grouping or aggregation of selected results.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TDatabase, TEntity> Having(AnyHavingExpression having);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectEntityContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> InnerJoin(AnyEntity entity);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectEntityContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> InnerJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectEntityContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> LeftJoin(AnyEntity entity);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectEntityContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> LeftJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectEntityContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> RightJoin(AnyEntity entity);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectEntityContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> RightJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectEntityContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> FullJoin(AnyEntity entity);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectEntityContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a <typeparamref name="TEntity"/> entity.</returns>
        WithAlias<JoinOn<SelectEntityContinuation<TDatabase, TEntity>>> FullJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an CROSS JOIN clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="SelectEntityContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        SelectEntityContinuation<TDatabase, TEntity> CrossJoin(AnyEntity entity);
    }
}
