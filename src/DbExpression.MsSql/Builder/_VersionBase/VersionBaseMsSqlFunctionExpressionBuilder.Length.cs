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

using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder;
using DbExpression.Sql.Expression;
using System;

namespace DbExpression.MsSql.Builder
{
    public partial class VersionBaseMsSqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the LEN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/len">read the docs on LEN</see></para>
        /// </summary>
        /// <param name="element">A <see cref="StringElement"/> for determining the number of characters, excluding trailing spaces.</param>
        /// <returns><see cref="Int64LengthFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64LengthFunctionExpression Len(StringElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the LEN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/len">read the docs on LEN</see></para>
        /// </summary>
        /// <param name="element">A <see cref="NullableStringElement"/> for determining the number of characters, excluding trailing spaces.</param>
        /// <returns><see cref="NullableInt64LengthFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64LengthFunctionExpression Len(NullableStringElement element)
            => new(element);
    }
}
