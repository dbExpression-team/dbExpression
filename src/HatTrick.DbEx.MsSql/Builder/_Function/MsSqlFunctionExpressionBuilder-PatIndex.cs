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

using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class MsSqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> literal to be found.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/> the expression to search.</param>
        /// <returns><see cref="Int64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64PatIndexFunctionExpression PatIndex(string pattern, AnyElement<string> element)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new Int64PatIndexFunctionExpression(new LiteralExpression<string>(pattern), element);
        }

        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> that contains the expression to be found.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/> the expression to search.</param>
        /// <returns><see cref="Int64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64PatIndexFunctionExpression PatIndex(AnyElement<string> pattern, AnyElement<string> element)
            => new Int64PatIndexFunctionExpression(pattern, element);

        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> literal to be found.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <returns><see cref="NullableInt64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64PatIndexFunctionExpression PatIndex(string pattern, NullableStringElement element)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64PatIndexFunctionExpression(new LiteralExpression<string>(pattern), element);
        }

        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/> that contains the expression to be found.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <returns><see cref="NullableInt64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64PatIndexFunctionExpression PatIndex(AnyElement<string> pattern, NullableStringElement element)
            => new NullableInt64PatIndexFunctionExpression(pattern, element);
    }
}
