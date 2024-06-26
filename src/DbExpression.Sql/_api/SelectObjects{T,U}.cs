﻿#region license
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

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectObjects<TDatabase, TObject>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        /// <summary>
        /// Construct a TOP clause for a sql SELECT query expression to limit the number of <typeparamref name="TObject"/> values selected.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="value">The maximum number of records to select from the database.</param>
        /// <returns><see cref="SelectObjects{TDatabase, TValue}"/>, a fluent continuation for constructing a sql SELECT query expression for a list of <typeparamref name="TObject"/> values.</returns>
        SelectObjects<TDatabase, TObject> Top(int value);

        /// <summary>
        /// Construct a DISTINCT clause for a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectObjects{TDatabase, TValue}"/>, a fluent continuation for constructing a sql SELECT query expression for a list of <typeparamref name="TObject"/> values.</returns>
        SelectObjects<TDatabase, TObject> Distinct();

        /// <summary>
        /// Construct the FROM clause of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntitiesContinuation{TDatabase, TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TObject"/> values.</returns>
        SelectObjectsContinuation<TDatabase, TObject> From<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity;

        /// <summary>
        /// Construct the FROM clause of a sql SELECT query expression for a list of <typeparamref name="dynamic"/> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="WithAlias{SelectObjectsContinuation{TDatabase, TObject}}"/>, a fluent continuation for providing an alias for the subquery.</returns>
        WithAlias<SelectObjectsContinuation<TDatabase, TObject>> From(AnySelectSubquery query);
    }
}
