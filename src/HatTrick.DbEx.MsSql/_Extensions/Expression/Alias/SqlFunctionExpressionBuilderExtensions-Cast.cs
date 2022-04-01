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

using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Expression.Alias
{
    public static partial class SqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to convert to a different sql data type.</param>
        /// <returns><see cref="MsSqlCast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(this MsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) element)
            => new MsSqlCastFunctionExpressionBuilder(new AliasExpression<object>(element));        
    }
}
