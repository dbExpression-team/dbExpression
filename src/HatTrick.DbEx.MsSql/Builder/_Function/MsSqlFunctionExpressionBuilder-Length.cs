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
        /// Construct an expression for the LEN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/len-transact-sql">Microsoft docs on LEN</see></para>
        /// </summary>
        /// <param name="element">A <see cref="AnyElement{String}"/> for determining the number of characters, excluding trailing spaces.</param>
        /// <returns><see cref="Int64LengthFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64LengthFunctionExpression Len(AnyElement<string> element)
            => new Int64LengthFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the LEN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/len-transact-sql">Microsoft docs on LEN</see></para>
        /// </summary>
        /// <param name="element">A <see cref="NullableStringElement"/> for determining the number of characters, excluding trailing spaces.</param>
        /// <returns><see cref="NullableInt64LengthFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64LengthFunctionExpression Len(NullableStringElement element)
            => new NullableInt64LengthFunctionExpression(element);
    }
}
