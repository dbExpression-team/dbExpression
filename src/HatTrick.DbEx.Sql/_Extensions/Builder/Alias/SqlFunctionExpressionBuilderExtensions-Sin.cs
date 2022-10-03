﻿#region license
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

namespace HatTrick.DbEx.Sql.Builder.Alias
{
    public static partial class SqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the SIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sin-transact-sql">Microsoft docs on SIN</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression, the value to use for calculating the sine function result.</param>
        /// <returns><see cref="NullableSingleSinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleSinFunctionExpression Sin(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element)
            => new(new AliasExpression<float?>(element));
    }
}
