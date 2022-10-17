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

namespace HatTrick.DbEx.MsSql.Builder.Alias
{
    public static partial class Version2017PlusMsSqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the TRIM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/trim?version=0.9.4">read the docs on TRIM</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to trim leading and trailing spaces from.</param>
        /// <returns><see cref="NullableStringTrimFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringTrimFunctionExpression Trim(this Version2017PlusMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) element)
            => new(new AliasExpression<string?>(element));
    }
}
