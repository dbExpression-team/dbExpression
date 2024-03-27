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
using System.Dynamic;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectDynamicContinuation<TDatabase> : 
#pragma warning restore IDE1006 // Naming Styles
        UnionSelectDynamicsInitiation<TDatabase>,
        SelectDynamicTermination<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Construct the WHERE clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="where">Any filter predicate of type <see cref="AnyWhereExpression"/>.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> Where(AnyWhereExpression where);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="AnyOrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> OrderBy(params AnyOrderByExpression[] orderBy);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="OrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> OrderBy(params OrderByExpression[] orderBy);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="AnyOrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> OrderBy(IEnumerable<AnyOrderByExpression> orderBy);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/order-by">read the docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="OrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> OrderBy(IEnumerable<OrderByExpression> orderBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> GroupBy(params AnyGroupByExpression[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="GroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> GroupBy(params GroupByExpression[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> GroupBy(IEnumerable<AnyGroupByExpression> groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/group-by">read the docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="GroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> GroupBy(IEnumerable<GroupByExpression> groupBy);

        /// <summary>
        /// Construct the HAVING clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/having">read the docs on HAVING</see>
        /// </para>
        /// </summary>
        /// <param name="having">A list of expressions of type <see cref="AnyHavingExpression"/> specifying conditions on the grouping or aggregation of selected results.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> Having(AnyHavingExpression having);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectDynamicContinuation{TDatabase}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        JoinOn<SelectDynamicContinuation<TDatabase>> InnerJoin(AnyEntity entity);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectDynamicContinuation{TDatabase}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> InnerJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectDynamicContinuation{TDatabase}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        JoinOn<SelectDynamicContinuation<TDatabase>> LeftJoin(AnyEntity entity);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectDynamicContinuation{TDatabase}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> LeftJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectDynamicContinuation{TDatabase}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        JoinOn<SelectDynamicContinuation<TDatabase>> RightJoin(AnyEntity entity);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectDynamicContinuation{TDatabase}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> RightJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectDynamicContinuation{TDatabase}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        JoinOn<SelectDynamicContinuation<TDatabase>> FullJoin(AnyEntity entity);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectDynamicContinuation{TDatabase}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="dynamic"/> value.</returns>
        WithAlias<JoinOn<SelectDynamicContinuation<TDatabase>>> FullJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an CROSS JOIN clause of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="SelectDynamicContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="dynamic"/> value.</returns>
        SelectDynamicContinuation<TDatabase> CrossJoin(AnyEntity entity);
    }
}
