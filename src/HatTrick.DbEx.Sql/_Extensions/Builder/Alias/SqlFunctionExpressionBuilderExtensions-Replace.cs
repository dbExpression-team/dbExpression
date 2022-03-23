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

using _ = HatTrick.DbEx.Sql.Builder.SqlFunctionExpressionBuilder;

namespace HatTrick.DbEx.Sql.Builder.Alias
{
    public static partial class SqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An <see cref="string"/> literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, string? pattern, string? replacement)
            => new(new AliasExpression<string?>(element), new LiteralExpression<string?>(pattern), new LiteralExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An <see cref="string"/> literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, string? element, (string TableName, string FieldName) pattern, string? replacement)
            => new(new LiteralExpression<string?>(element), new AliasExpression<string?>(pattern), new LiteralExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, string? element, string? pattern, (string TableName, string FieldName) replacement)
            => new(new LiteralExpression<string?>(element), new LiteralExpression<string?>(pattern), new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, (string TableName, string FieldName) pattern, (string TableName, string FieldName) replacement)
            => new(new AliasExpression<string?>(element), new AliasExpression<string?>(pattern), new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An <see cref="string"/> literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, (string TableName, string FieldName) pattern, string? replacement)
            => new(new AliasExpression<string?>(element), new AliasExpression<string?>(pattern), new LiteralExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, string? element, (string TableName, string FieldName) pattern, (string TableName, string FieldName) replacement)
            => new(new LiteralExpression<string?>(element), new AliasExpression<string?>(pattern), new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, string? pattern, (string TableName, string FieldName) replacement)
            => new(new AliasExpression<string?>(element), new LiteralExpression<string?>(pattern), new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, AnyStringElement pattern, AnyStringElement replacement)
            => new(new AliasExpression<string?>(element), pattern, replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, AnyStringElement element, (string TableName, string FieldName) pattern, AnyStringElement replacement)
            => new(element, new AliasExpression<string?>(pattern), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, AnyStringElement element, AnyStringElement pattern, (string TableName, string FieldName) replacement)
            => new(element, pattern, new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, (string TableName, string FieldName) pattern, AnyStringElement replacement)
            => new(new AliasExpression<string?>(element), new AliasExpression<string?>(pattern), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, AnyStringElement element, (string TableName, string FieldName) pattern, (string TableName, string FieldName) replacement)
            => new(element, new AliasExpression<string?>(pattern), new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, AnyStringElement pattern, (string TableName, string FieldName) replacement)
            => new(new AliasExpression<string?>(element), pattern, new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, string? pattern, AnyStringElement replacement)
            => new(new AliasExpression<string?>(element), new LiteralExpression<string?>(pattern), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An expression of type <see cref="AnyStringElement"/> which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, string? element, (string TableName, string FieldName) pattern, AnyStringElement replacement)
            => new(new LiteralExpression<string?>(element), new AliasExpression<string?>(pattern), replacement);

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">A <see cref="string"/> literal to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, string? element, AnyStringElement pattern, (string TableName, string FieldName) replacement)
            => new(new LiteralExpression<string?>(element), pattern, new AliasExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="AnyStringElement"/> to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An <see cref="string"/> literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, (string TableName, string FieldName) element, AnyStringElement pattern, string? replacement)
            => new(new AliasExpression<string?>(element), pattern, new LiteralExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">An alias of an expression used as value to find a match in <paramref name="element"/>.</param>
        /// <param name="replacement">An <see cref="string"/> literal which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, AnyStringElement element, (string TableName, string FieldName) pattern, string? replacement)
            => new(element, new AliasExpression<string?>(pattern), new LiteralExpression<string?>(replacement));

        /// <summary>
        /// Construct an expression for the REPLACE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/replace-transact-sql">Microsoft docs on REPLACE</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyStringElement"/> to replace all occurrences of <paramref name="pattern"/> with <paramref name="replacement"/>.</param>
        /// <param name="pattern">A <see cref="string"/> literal to match in <paramref name="element"/>.</param>
        /// <param name="replacement">An alias of an expression which will replace all occurences of <paramref name="pattern"/> in <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringReplaceFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringReplaceFunctionExpression Replace(this _ _, AnyStringElement element, string? pattern, (string TableName, string FieldName) replacement)
            => new(element, new LiteralExpression<string?>(pattern), new AliasExpression<string?>(replacement));
    }
}
