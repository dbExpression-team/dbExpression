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
    public partial  class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32AverageFunctionExpression Avg(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}?/>.</returns>
        public NullableInt32AverageFunctionExpression Avg(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32AverageFunctionExpression Avg(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}?/>.</returns>
        public NullableInt32AverageFunctionExpression Avg(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32AverageFunctionExpression Avg(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt32AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}?/>.</returns>
        public NullableInt32AverageFunctionExpression Avg(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="Int64AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64AverageFunctionExpression Avg(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableInt64AverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}?/>.</returns>
        public NullableInt64AverageFunctionExpression Avg(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="SingleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleAverageFunctionExpression Avg(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableSingleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}?/>.</returns>
        public NullableSingleAverageFunctionExpression Avg(AnyElement<float?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="DoubleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleAverageFunctionExpression Avg(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableDoubleAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}?/>.</returns>
        public NullableDoubleAverageFunctionExpression Avg(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the average function result.</param>
        /// <returns><see cref="DecimalAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalAverageFunctionExpression Avg(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the AVG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/avg">read the docs on AVG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the average function result.</param>
        /// <returns><see cref="NullableDecimalAverageFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}?/>.</returns>
        public NullableDecimalAverageFunctionExpression Avg(AnyElement<decimal?> element)
            => new(element);
    }
}
