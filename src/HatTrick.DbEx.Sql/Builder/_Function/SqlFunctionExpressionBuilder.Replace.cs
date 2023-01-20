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
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringReplaceFunctionExpression Replace(string element, StringElement pattern, StringElement replacement)
            => new(new LiteralExpression<string?>(element), pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">A <see cref="string"/>? literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a c.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(string? element, StringElement pattern, string? replacement)
            => new(new LiteralExpression<string?>(element), pattern, new NullableStringExpressionMediator(new LiteralExpression<string?>(replacement)));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/>? literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="StringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(string? element, string? pattern, StringElement replacement)
            => new(new LiteralExpression<string?>(element), new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref=AnyStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">A <see cref="string"/>? literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(string? element, AnyStringElement pattern, string? replacement)
            => new(new LiteralExpression<string?>(element), pattern, new NullableStringExpressionMediator(new LiteralExpression<string?>(replacement)));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/>? literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(string? element, string? pattern, AnyStringElement replacement)
            => new(new LiteralExpression<string?>(element), new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyStringElement"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(string? element, AnyStringElement pattern, AnyStringElement replacement)
            => new(new LiteralExpression<string?>(element), pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">A <see cref="string"/> literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringReplaceFunctionExpression Replace(StringElement element, string pattern, string replacement)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new(element, new LiteralExpression<string>(pattern), new LiteralExpression<string>(replacement));
        }

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">A <see cref="string"/> literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringReplaceFunctionExpression Replace(StringElement element, StringElement pattern, string replacement)
        {
            return new(element, pattern, new LiteralExpression<string>(replacement));
        }

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringReplaceFunctionExpression Replace(StringElement element, string pattern, StringElement replacement)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new(element, new LiteralExpression<string>(pattern), replacement);
        }

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringReplaceFunctionExpression Replace(StringElement element, StringElement pattern, StringElement replacement)
            => new(element, pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/>? literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">A <see cref="string"/>? literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(NullableStringElement element, string? pattern, string? replacement)
            => new(element, new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new LiteralExpression<string?>(replacement)));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">A <see cref="string"/>? literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(NullableStringElement element, StringElement pattern, string? replacement)
            => new(element, pattern, new NullableStringExpressionMediator(new LiteralExpression<string?>(replacement)));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/>? literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="StringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(NullableStringElement element, string? pattern, StringElement replacement)
            => new(element, new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref=AnyStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">A <see cref="string"/>? literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(NullableStringElement element, AnyStringElement pattern, string? replacement)
            => new(element, pattern, new NullableStringExpressionMediator(new LiteralExpression<string?>(replacement)));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/>? literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(NullableStringElement element, string? pattern, AnyStringElement replacement)
            => new(element, new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/replace?version=0.9.5">read the docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyStringElement"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public virtual NullableStringReplaceFunctionExpression Replace(NullableStringElement element, AnyStringElement pattern, AnyStringElement replacement)
            => new(element, pattern, replacement);
    }
}
