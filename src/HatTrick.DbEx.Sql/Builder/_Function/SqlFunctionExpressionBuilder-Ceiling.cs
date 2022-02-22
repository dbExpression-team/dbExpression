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
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="ByteCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static ByteCeilingFunctionExpression Ceiling(AnyElement<byte> element)
            => new ByteCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableByteCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public static NullableByteCeilingFunctionExpression Ceiling(AnyElement<byte?> element)
            => new NullableByteCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int16CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16CeilingFunctionExpression Ceiling(AnyElement<short> element)
            => new Int16CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt16CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16CeilingFunctionExpression Ceiling(AnyElement<short?> element)
            => new NullableInt16CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int32CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32CeilingFunctionExpression Ceiling(AnyElement<int> element)
            => new Int32CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt32CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32CeilingFunctionExpression Ceiling(AnyElement<int?> element)
            => new NullableInt32CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int64CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CeilingFunctionExpression Ceiling(AnyElement<long> element)
            => new Int64CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt64CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CeilingFunctionExpression Ceiling(AnyElement<long?> element)
            => new NullableInt64CeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="SingleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleCeilingFunctionExpression Ceiling(AnyElement<float> element)
            => new SingleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableSingleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleCeilingFunctionExpression Ceiling(AnyElement<float?> element)
            => new NullableSingleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="DoubleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleCeilingFunctionExpression Ceiling(AnyElement<double> element)
            => new DoubleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableDoubleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleCeilingFunctionExpression Ceiling(AnyElement<double?> element)
            => new NullableDoubleCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="DecimalCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalCeilingFunctionExpression Ceiling(AnyElement<decimal> element)
            => new DecimalCeilingFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/ceiling-transact-sql">Microsoft docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableDecimalCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalCeilingFunctionExpression Ceiling(AnyElement<decimal?> element)
            => new NullableDecimalCeilingFunctionExpression(element);
    }
}
