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
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="ByteCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public ByteCeilingFunctionExpression Ceiling(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableByteCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public NullableByteCeilingFunctionExpression Ceiling(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int16CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public Int16CeilingFunctionExpression Ceiling(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt16CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public NullableInt16CeilingFunctionExpression Ceiling(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int32CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32CeilingFunctionExpression Ceiling(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt32CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32CeilingFunctionExpression Ceiling(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="Int64CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CeilingFunctionExpression Ceiling(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableInt64CeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CeilingFunctionExpression Ceiling(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="SingleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleCeilingFunctionExpression Ceiling(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableSingleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleCeilingFunctionExpression Ceiling(AnyElement<float?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="DoubleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleCeilingFunctionExpression Ceiling(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableDoubleCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public NullableDoubleCeilingFunctionExpression Ceiling(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="DecimalCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalCeilingFunctionExpression Ceiling(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the CEILING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/ceiling?version=0.9.5">read the docs on CEILING</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the ceiling function result.</param>
        /// <returns><see cref="NullableDecimalCeilingFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public NullableDecimalCeilingFunctionExpression Ceiling(AnyElement<decimal?> element)
            => new(element);
    }
}
