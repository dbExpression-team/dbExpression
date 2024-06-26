﻿#region license
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

using DbExpression.Sql.Expression;

namespace DbExpression.Sql.Builder.Alias
{
    public static partial class SqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/abs">read the docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableObjectAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement"/>.</returns>
        public static NullableObjectAbsFunctionExpression Abs(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element)
            => new(new AliasExpression<object?>(element));
    }
}
