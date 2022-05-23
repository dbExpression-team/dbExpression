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
    public interface SelectObjectsOrderByContinuation<TDatabase, TObject>
#pragma warning restore IDE1006 // Naming Styles
        : SelectObjectsTermination<TDatabase, TObject>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        /// <summary>
        /// Specify a number of records to ignore while reading before beginning to return records.
        /// </summary>
        /// <param name="Object">The number of records to ignore.</param>
        /// <returns><see cref="SelectObjectsOffsetContinuation{TDatabase, TObject}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TObject"/> Objects.</returns>
        SelectObjectsOffsetContinuation<TDatabase, TObject> Offset(int Object);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a list of <typeparamref name="TObject"/> Objects.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByClause"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectObjectsOrderByContinuation{TDatabase, TObject}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TObject"/> Objects.</returns>
        SelectObjectsOrderByContinuation<TDatabase, TObject> GroupBy(params AnyGroupByClause[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a list of <typeparamref name="TObject"/> Objects.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByClause"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectObjectsOrderByContinuation{TDatabase, TObject}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TObject"/> Objects.</returns>
        SelectObjectsOrderByContinuation<TDatabase, TObject> GroupBy(IEnumerable<AnyGroupByClause>? groupBy);

        /// <summary>
        /// Construct the HAVING clause of a sql SELECT query expression for a list of <typeparamref name="TObject"/> Objects.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-having-transact-sql">Microsoft docs on HAVING</see>
        /// </para>
        /// </summary>
        /// <param name="having">A list of expressions of type <see cref="AnyHavingClause"/> specifying conditions on the grouping or aggregation of selected results.</param>
        /// <returns><see cref="SelectObjectsOrderByContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TObject"/> Objects.</returns>
        SelectObjectsOrderByContinuation<TDatabase, TObject> Having(AnyHavingClause? having);
    }
}
