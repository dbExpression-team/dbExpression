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

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectObject<TDatabase, TObject>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        /// <summary>
        /// Construct the FROM clause of a sql SELECT query expression for a single <typeparamref name="TObject"/> value.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectObjectContinuation{TDatabase,TObject}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TObject"/> value.</returns>
        SelectObjectContinuation<TDatabase, TObject> From<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity;

        /// <summary>
        /// Construct the FROM clause of a sql SELECT query expression for a list of <typeparamref name="dynamic"/> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="WithAlias{SelectObjectContinuation{TDatabase, TObject}}"/>, a fluent continuation for providing an alias for the subquery.</returns>
        WithAlias<SelectObjectContinuation<TDatabase, TObject>> From(AnySelectSubquery query);
    }
}
