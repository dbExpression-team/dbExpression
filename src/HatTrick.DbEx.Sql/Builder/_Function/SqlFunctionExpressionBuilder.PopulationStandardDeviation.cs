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
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<decimal?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="SinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the STDEVP transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/stdevp?version=0.9.5">read the docs on STDEVP</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the population standard deviation function result.</param>
        /// <returns><see cref="NullableSinglePopulationStandardDeviationFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSinglePopulationStandardDeviationFunctionExpression StDevP(AnyElement<float?> element)
            => new(element);
    }
}
