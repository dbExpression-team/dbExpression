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
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public virtual SingleStandardDeviationFunctionExpression StDev(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public virtual NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public virtual SingleStandardDeviationFunctionExpression StDev(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public virtual NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public virtual SingleStandardDeviationFunctionExpression StDev(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public virtual NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public virtual SingleStandardDeviationFunctionExpression StDev(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public virtual NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public virtual SingleStandardDeviationFunctionExpression StDev(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public virtual NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public virtual SingleStandardDeviationFunctionExpression StDev(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public virtual NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<decimal?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="SingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public virtual SingleStandardDeviationFunctionExpression StDev(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEV transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdev">read the docs on STDEV</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the standard deviation function result.</param>
        /// <returns><see cref="NullableSingleStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public virtual NullableSingleStandardDeviationFunctionExpression StDev(AnyElement<float?> element)
            => new(element);
    }
}
