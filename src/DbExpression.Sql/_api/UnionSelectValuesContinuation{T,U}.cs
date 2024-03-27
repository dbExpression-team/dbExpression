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

using DbExpression.Sql.Builder;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UnionSelectValuesContinuation<TDatabase, TValue> :
#pragma warning restore IDE1006 // Naming Styles
        IExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TValue> SelectOne(AnyElement<TValue> element);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TValue> SelectOne(StringElement element);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TValue> SelectOne(NullableStringElement element);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TValue> SelectMany(AnyElement<TValue> element);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TValue> SelectMany(StringElement element);

        /// <summary>
        /// Continue a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/select-statement">read the docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TDatabase, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        SelectValues<TDatabase, TValue> SelectMany(NullableStringElement element);
    }
}
