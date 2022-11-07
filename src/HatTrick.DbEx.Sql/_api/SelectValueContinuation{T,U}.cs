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

using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValueContinuation<TDatabase, TValue> : 
#pragma warning restore IDE1006 // Naming Styles
        SelectValueTermination<TDatabase, TValue>,
        UnionSelectValuesInitiation<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Construct the WHERE clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/where-transact-sql">Microsoft docs on WHERE</see>
        /// </para>
        /// </summary>
        /// <param name="where">Any filter predicate of type <see cref="AnyWhereExpression"/>.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> Where(AnyWhereExpression? where);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-order-by-clause-transact-sql">Microsoft docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="AnyOrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> OrderBy(params AnyOrderByExpression[] orderBy);

        /// <summary>
        /// Construct the ORDER BY clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-order-by-clause-transact-sql">Microsoft docs on ORDER BY</see>
        /// </para>
        /// </summary>
        /// <param name="orderBy">A list of expressions of type <see cref="AnyOrderByExpression"/> indicating the order and direction for sorting.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> OrderBy(IEnumerable<AnyOrderByExpression>? orderBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> GroupBy(params AnyGroupByExpression[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="GroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> GroupBy(params GroupByExpression[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> GroupBy(IEnumerable<AnyGroupByExpression>? groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="GroupByExpression"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> GroupBy(IEnumerable<GroupByExpression>? groupBy);

        /// <summary>
        /// Construct the HAVING clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-having-transact-sql">Microsoft docs on HAVING</see>
        /// </para>
        /// </summary>
        /// <param name="having">A list of expressions of type <see cref="AnyHavingExpression"/> specifying conditions on the grouping or aggregation of selected results.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> Having(AnyHavingExpression? having);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectValueContinuation{TDatabase, TValue}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        JoinOn<SelectValueContinuation<TDatabase, TValue>> InnerJoin(AnyEntity entity);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectValueContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> InnerJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectValueContinuation{TDatabase, TValue}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        JoinOn<SelectValueContinuation<TDatabase, TValue>> LeftJoin(AnyEntity entity);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectValueContinuation{TDatabase, TValue}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> LeftJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectValueContinuation{TDatabase, TValue}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        JoinOn<SelectValueContinuation<TDatabase, TValue>> RightJoin(AnyEntity entity);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectValueContinuation{TDatabase, TValue}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> RightJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{SelectValueContinuation{TDatabase, TValue}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        JoinOn<SelectValueContinuation<TDatabase, TValue>> FullJoin(AnyEntity entity);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{SelectValueContinuation{TDatabase, TValue}}}"/>, a fluent continuation for the construction of a sql JOIN expression for a single <typeparamref name="TValue"/> value.</returns>
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> FullJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an CROSS JOIN clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="SelectValueContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TDatabase, TValue> CrossJoin(AnyEntity entity);
    }
}
