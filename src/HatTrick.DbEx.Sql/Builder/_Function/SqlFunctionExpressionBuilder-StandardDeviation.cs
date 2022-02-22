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
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(AnyElement<byte> element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<byte?> element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(AnyElement<short> element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<short?> element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(AnyElement<int> element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<int?> element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(AnyElement<long> element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<long?> element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(AnyElement<double> element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<double?> element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(AnyElement<decimal> element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<decimal?> element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleStandardDeviationFunctionExpression StDev(AnyElement<float> element)
            => new SingleStandardDeviationFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/stdev-transact-sql">Microsoft docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<float?> element)
            => new NullableSingleStandardDeviationFunctionExpression(element);
    }
}
