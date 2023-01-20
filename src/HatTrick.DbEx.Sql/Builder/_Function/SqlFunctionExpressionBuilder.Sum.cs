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
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32SumFunctionExpression Sum(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32SumFunctionExpression Sum(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32SumFunctionExpression Sum(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32SumFunctionExpression Sum(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32SumFunctionExpression Sum(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://www.dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt32SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32SumFunctionExpression Sum(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="Int64SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64SumFunctionExpression Sum(AnyElement<long> element)
            => new Int64SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableInt64SumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64SumFunctionExpression Sum(AnyElement<long?> element)
            => new NullableInt64SumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="DoubleSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleSumFunctionExpression Sum(AnyElement<double> element)
            => new DoubleSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableDoubleSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public NullableDoubleSumFunctionExpression Sum(AnyElement<double?> element)
            => new NullableDoubleSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="DecimalSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalSumFunctionExpression Sum(AnyElement<decimal> element)
            => new DecimalSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableDecimalSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public NullableDecimalSumFunctionExpression Sum(AnyElement<decimal?> element)
            => new NullableDecimalSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="SingleSumFunctionExpression"/> for use with any operation accepting a  <see cref="AnyElement{Single}"/>?.</returns>
        public SingleSumFunctionExpression Sum(AnyElement<float> element)
            => new SingleSumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the SUM transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/sum?version=0.9.5">read the docs on SUM</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the sum function result.</param>
        /// <returns><see cref="NullableSingleSumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleSumFunctionExpression Sum(AnyElement<float?> element)
            => new NullableSingleSumFunctionExpression(element);
    }
}
