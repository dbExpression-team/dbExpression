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

using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder.Alias
{
    public static partial class Version2012PlusMsSqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the TRIM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log>read the docs on TRIM</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleLogFunctionExpression Log(this Version2012PlusMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) element, int @base)
            => new(new AliasExpression<float?>(element), new LiteralExpression<int>(@base));

        /// <summary>
        /// Construct an expression for the TRIM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log>read the docs on TRIM</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleLogFunctionExpression Log(this Version2012PlusMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) element, (string TableName, string FieldName) @base)
            => new(new AliasExpression<float?>(element), new AliasExpression<int?>(@base));

        /// <summary>
        /// Construct an expression for the TRIM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log>read the docs on TRIM</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleLogFunctionExpression Log(this Version2012PlusMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) element, AnyElement<int> @base)
            => new(new AliasExpression<float?>(element), @base);

        /// <summary>
        /// Construct an expression for the TRIM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log>read the docs on TRIM</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleLogFunctionExpression Log(this Version2012PlusMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) element, AnyElement<int?> @base)
            => new(new AliasExpression<float?>(element), @base);

        /// <summary>
        /// Construct an expression for the TRIM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log>read the docs on TRIM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyNumericElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An alias of a value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleLogFunctionExpression Log(this Version2012PlusMsSqlFunctionExpressionBuilder _, AnyNumericElement element, (string TableName, string FieldName) @base)
            => new(element, new AliasExpression<int?>(@base));
    }
}
