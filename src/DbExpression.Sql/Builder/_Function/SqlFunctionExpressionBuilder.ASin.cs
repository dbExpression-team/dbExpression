#region license
// Copyright (c) HatTrick Larcsine, LLC.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/HatTrickLarcsine/db-ex
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
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="SingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleASinFunctionExpression ASin(Int16Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="NullableSingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleASinFunctionExpression ASin(NullableInt16Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="SingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleASinFunctionExpression ASin(Int32Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="NullableSingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleASinFunctionExpression ASin(NullableInt32Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="SingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleASinFunctionExpression ASin(Int64Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="NullableSingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleASinFunctionExpression ASin(NullableInt64Element element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="SingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleASinFunctionExpression ASin(SingleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="NullableSingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleASinFunctionExpression ASin(NullableSingleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="SingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleASinFunctionExpression ASin(DoubleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="NullableSingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleASinFunctionExpression ASin(NullableDoubleElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="SingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleASinFunctionExpression ASin(DecimalElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ASIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/asin">read the docs on ASIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the arcsine value.</param>
        /// <returns><see cref="NullableSingleASinFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleASinFunctionExpression ASin(NullableDecimalElement element)
            => new(element);
    }
}
