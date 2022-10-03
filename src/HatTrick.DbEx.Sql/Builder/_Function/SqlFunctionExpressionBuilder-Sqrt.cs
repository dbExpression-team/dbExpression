#region license
// Copyright (c) HatTrick Lsquare root, LLC.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/HatTrickLsquare root/db-ex
#endregion

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="SingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleSqrtFunctionExpression Sqrt(Int16Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="NullableSingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleSqrtFunctionExpression Sqrt(NullableInt16Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="SingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleSqrtFunctionExpression Sqrt(Int32Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="NullableSingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleSqrtFunctionExpression Sqrt(NullableInt32Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="SingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleSqrtFunctionExpression Sqrt(Int64Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="NullableSingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleSqrtFunctionExpression Sqrt(NullableInt64Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="SingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleSqrtFunctionExpression Sqrt(SingleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="NullableSingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleSqrtFunctionExpression Sqrt(NullableSingleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="SingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleSqrtFunctionExpression Sqrt(DoubleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="NullableSingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleSqrtFunctionExpression Sqrt(NullableDoubleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="SingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleSqrtFunctionExpression Sqrt(DecimalElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SQRT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sqrt-transact-sql">Microsoft docs on SQRT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the square root value.</param>
        /// <returns><see cref="NullableSingleSqrtFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleSqrtFunctionExpression Sqrt(NullableDecimalElement element)
            => new(element);
    }
}
