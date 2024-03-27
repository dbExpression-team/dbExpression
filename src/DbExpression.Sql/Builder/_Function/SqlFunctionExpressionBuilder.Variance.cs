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

using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleVarianceFunctionExpression Var(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleVarianceFunctionExpression Var(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleVarianceFunctionExpression Var(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleVarianceFunctionExpression Var(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public SingleVarianceFunctionExpression Var(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="NullableSingleElement"/>.</returns>
        public NullableSingleVarianceFunctionExpression Var(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleVarianceFunctionExpression Var(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleVarianceFunctionExpression Var(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleVarianceFunctionExpression Var(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleVarianceFunctionExpression Var(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleVarianceFunctionExpression Var(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleVarianceFunctionExpression Var(AnyElement<decimal?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="SingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleVarianceFunctionExpression Var(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VAR transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/aggregate/var">read the docs on VAR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the variance function result.</param>
        /// <returns><see cref="NullableSingleVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleVarianceFunctionExpression Var(AnyElement<float?> element)
            => new(element);
    }
}
