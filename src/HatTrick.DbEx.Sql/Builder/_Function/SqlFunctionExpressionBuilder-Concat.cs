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
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/concat?version=0.9.5">read the docs on CONCAT</see></para>
        /// </summary>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to join into a single string.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringConcatFunctionExpression Concat(params AnyStringElement[] elements)
            => new(elements);

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/concat?version=0.9.5">read the docs on CONCAT</see></para>
        /// </summary>
        /// <param name="value">The beginning part of the joined string.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyStringElement"/>.</returns>
        public StringConcatFunctionExpression Concat(string? value, params AnyStringElement[] elements)
            => new(new List<AnyStringElement> { new NullableStringExpressionMediator(new LiteralExpression<string?>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/concat?version=0.9.5">read the docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyStringElement"/>, the beginning part of the joined string.</param>
        /// <param name="value">The part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyStringElement"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringConcatFunctionExpression Concat(AnyStringElement element1, string? value, params AnyStringElement[] elements)
            => new(new List<AnyStringElement> { element1, new NullableStringExpressionMediator(new LiteralExpression<string?>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/concat?version=0.9.5">read the docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement{String}"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement{String}"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyElement{String}"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, string? value, params AnyStringElement[] elements)
            => new(new List<AnyStringElement> { element1, element2, new NullableStringExpressionMediator(new LiteralExpression<string?>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/concat?version=0.9.5">read the docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement{String}"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement{String}"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement{String}"/>, the part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element3"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyElement{String}"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, string? value, params AnyStringElement[] elements)
            => new(new List<AnyStringElement> { element1, element2, element3, new NullableStringExpressionMediator(new LiteralExpression<string?>(value)) }.Concat(elements).ToArray());

        /// <summary>
        /// Construct an expression for the CONCAT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/concat?version=0.9.5">read the docs on CONCAT</see></para>
        /// </summary>
        /// <param name="element1">An expression of type <see cref="AnyElement{String}"/>, the beginning part of the joined string.</param>
        /// <param name="element2">An expression of type <see cref="AnyElement{String}"/>, the part of the joined string after <paramref name="element1"/>.</param>
        /// <param name="element3">An expression of type <see cref="AnyElement{String}"/>, the part of the joined string after <paramref name="element2"/>.</param>
        /// <param name="element4">An expression of type <see cref="AnyElement{String}"/>, the part of the joined string after <paramref name="element3"/>.</param>
        /// <param name="value">The part of the joined string after <paramref name="element4"/>.</param>
        /// <param name="elements">A list of expressions of type <see cref="AnyElement{String}"/> to add to the string after <paramref name="value"/>.</param>
        /// <returns><see cref="StringConcatFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, AnyStringElement element4, string? value, params AnyStringElement[] elements)
            => new(new List<AnyStringElement> { element1, element2, element3, element4, new NullableStringExpressionMediator(new LiteralExpression<string?>(value)) }.Concat(elements).ToArray());
    }
}
