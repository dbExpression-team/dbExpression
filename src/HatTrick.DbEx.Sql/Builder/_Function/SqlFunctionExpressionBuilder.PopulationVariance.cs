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
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationVarianceFunctionExpression VarP(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationVarianceFunctionExpression VarP(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationVarianceFunctionExpression VarP(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationVarianceFunctionExpression VarP(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public SinglePopulationVarianceFunctionExpression VarP(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="NullableSingleElement"/>.</returns>
        public NullableSinglePopulationVarianceFunctionExpression VarP(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationVarianceFunctionExpression VarP(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationVarianceFunctionExpression VarP(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationVarianceFunctionExpression VarP(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationVarianceFunctionExpression VarP(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationVarianceFunctionExpression VarP(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationVarianceFunctionExpression VarP(AnyElement<decimal?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="SinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationVarianceFunctionExpression VarP(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the VARP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/varp>read the docs on VARP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the population variance function result.</param>
        /// <returns><see cref="NullableSinglePopulationVarianceFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationVarianceFunctionExpression VarP(AnyElement<float?> element)
            => new(element);
    }
}
