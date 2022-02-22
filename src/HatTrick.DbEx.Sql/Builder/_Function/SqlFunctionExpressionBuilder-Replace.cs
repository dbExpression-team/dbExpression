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
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="string"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringReplaceFunctionExpression Replace(AnyElement<string> element, string pattern, string replacement)
            => new StringReplaceFunctionExpression(element, new LiteralExpression<string>(pattern), new LiteralExpression<string>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="string"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringReplaceFunctionExpression Replace(AnyElement<string> element, AnyElement<string> pattern, string replacement)
            => new StringReplaceFunctionExpression(element, pattern, new LiteralExpression<string>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringReplaceFunctionExpression Replace(AnyElement<string> element, string pattern, AnyElement<string> replacement)
            => new StringReplaceFunctionExpression(element, new LiteralExpression<string>(pattern), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="StringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringReplaceFunctionExpression Replace(AnyElement<string> element, AnyElement<string> pattern, AnyElement<string> replacement)
            => new StringReplaceFunctionExpression(element, pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="string"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, string pattern, string replacement)
            => new NullableStringReplaceFunctionExpression(element, new LiteralExpression<string>(pattern), new LiteralExpression<string>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="string"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, AnyElement<string> pattern, string replacement)
            => new NullableStringReplaceFunctionExpression(element, pattern, new LiteralExpression<string>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, string pattern, AnyElement<string> replacement)
            => new NullableStringReplaceFunctionExpression(element, new LiteralExpression<string>(pattern), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, AnyElement<string> pattern, AnyElement<string> replacement)
            => new NullableStringReplaceFunctionExpression(element, pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="string"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, NullableStringElement pattern, string replacement)
            => new NullableStringReplaceFunctionExpression(element, pattern, new LiteralExpression<string>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="NullableStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, string pattern, NullableStringElement replacement)
            => new NullableStringReplaceFunctionExpression(element, new LiteralExpression<string>(pattern), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="NullableStringElement"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="NullableStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, NullableStringElement pattern, NullableStringElement replacement)
            => new NullableStringReplaceFunctionExpression(element, pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyElement{String}"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, NullableStringElement pattern, AnyElement<string> replacement)
            => new NullableStringReplaceFunctionExpression(element, pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="NullableStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(NullableStringElement element, AnyElement<string> pattern, NullableStringElement replacement)
            => new NullableStringReplaceFunctionExpression(element, pattern, replacement);
    }
}
