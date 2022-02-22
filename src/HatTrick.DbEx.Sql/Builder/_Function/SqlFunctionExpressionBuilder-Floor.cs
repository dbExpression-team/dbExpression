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
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="ByteFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static ByteFloorFunctionExpression Floor(AnyElement<byte> element)
            => new ByteFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableByteFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public static NullableByteFloorFunctionExpression Floor(AnyElement<byte?> element)
            => new NullableByteFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="Int16FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16FloorFunctionExpression Floor(AnyElement<short> element)
            => new Int16FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableInt16FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16FloorFunctionExpression Floor(AnyElement<short?> element)
            => new NullableInt16FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="Int32FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32FloorFunctionExpression Floor(AnyElement<int> element)
            => new Int32FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableInt32FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32FloorFunctionExpression Floor(AnyElement<int?> element)
            => new NullableInt32FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="Int64FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64FloorFunctionExpression Floor(AnyElement<long> element)
            => new Int64FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableInt64FloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64FloorFunctionExpression Floor(AnyElement<long?> element)
            => new NullableInt64FloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="SingleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleFloorFunctionExpression Floor(AnyElement<float> element)
            => new SingleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableSingleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleFloorFunctionExpression Floor(AnyElement<float?> element)
            => new NullableSingleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="DoubleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleFloorFunctionExpression Floor(AnyElement<double> element)
            => new DoubleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableDoubleFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleFloorFunctionExpression Floor(AnyElement<double?> element)
            => new NullableDoubleFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="DecimalFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalFloorFunctionExpression Floor(AnyElement<decimal> element)
            => new DecimalFloorFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the FLOOR transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/floor-transact-sql">Microsoft docs on FLOOR</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the floor function result.</param>
        /// <returns><see cref="NullableDecimalFloorFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalFloorFunctionExpression Floor(AnyElement<decimal?> element)
            => new NullableDecimalFloorFunctionExpression(element);
    }
}
