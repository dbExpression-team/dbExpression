#region license
// Copyright (c) HatTrick Llog, LLC.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/HatTrickLlog/db-ex
#endregion

using DbExpression.Sql;
using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.MsSql.Builder
{
    public partial class Version2012PlusMsSqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(ByteElement element, int @base)
            => new(element, (@base > 1 ? new LiteralExpression<int>(@base) : throw new DbExpressionQueryException(element, ExceptionMessages.ValueMustBeGreaterThan(@base, 1))));

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableByteElement element, int @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(ByteElement element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableByteElement element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(Int16Element element, int @base)
            => new(element, (@base > 1 ? new LiteralExpression<int>(@base) : throw new DbExpressionQueryException(element, ExceptionMessages.ValueMustBeGreaterThan(@base, 1))));

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt16Element element, int @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(Int16Element element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt16Element element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(Int32Element element, int @base)
            => new(element, (@base > 1 ? new LiteralExpression<int>(@base) : throw new DbExpressionQueryException(element, ExceptionMessages.ValueMustBeGreaterThan(@base, 1))));

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt32Element element, int @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(Int32Element element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt32Element element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(Int64Element element, int @base)
            => new(element, (@base > 1 ? new LiteralExpression<int>(@base) : throw new DbExpressionQueryException(element, ExceptionMessages.ValueMustBeGreaterThan(@base, 1))));

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt64Element element, int @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(Int64Element element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt64Element element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(DecimalElement element, int @base)
            => new(element, (@base > 1 ? new LiteralExpression<int>(@base) : throw new DbExpressionQueryException(element, ExceptionMessages.ValueMustBeGreaterThan(@base, 1))));

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDecimalElement element, int @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(DecimalElement element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDecimalElement element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(DoubleElement element, int @base)
            => new(element, (@base > 1 ? new LiteralExpression<int>(@base) : throw new DbExpressionQueryException(element, ExceptionMessages.ValueMustBeGreaterThan(@base, 1))));

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDoubleElement element, int @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(DoubleElement element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDoubleElement element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(SingleElement element, int @base)
            => new(element, (@base > 1 ? new LiteralExpression<int>(@base) : throw new DbExpressionQueryException(element, ExceptionMessages.ValueMustBeGreaterThan(@base, 1))));

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableSingleElement element, int @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(SingleElement element, int? @base)
            => new(element);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">A value that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableSingleElement element, int? @base)
            => new(element);




        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/> that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(ByteElement element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(ByteElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableByteElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableByteElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/> that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableByteElement element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/> that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(Int16Element element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(Int16Element element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt16Element element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt16Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/> that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt16Element element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/> that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(Int32Element element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(Int32Element element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt32Element element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt32Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int32}"/> that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt32Element element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int64}"/> that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(Int64Element element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="Int64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int64}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(Int64Element element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int64}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt64Element element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableInt64Element"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Int64}"/> that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableInt64Element element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Decimal}"/> that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(DecimalElement element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Decimal}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(DecimalElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Decimal}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDecimalElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDecimalElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Decimal}"/> that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDecimalElement element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Double}"/> that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(DoubleElement element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="DoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Double}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(DoubleElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Double}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDoubleElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableDoubleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Double}"/> that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableDoubleElement element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Single}"/> that sets the base for the log function.</param>
        /// <returns><see cref="SingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleLogFunctionExpression Log(SingleElement element, AnyElement<int> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="SingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Single}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(SingleElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Single}"/>? that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableSingleElement element, AnyElement<int?> @base)
            => new(element, @base);

        /// <summary>
        /// Construct an expression for the LOG transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/log">read the docs on LOG</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the log value.</param>
        /// <param name="base">An expression of type <see cref="AnyElement{Single}"/> that sets the base for the log function.</param>
        /// <returns><see cref="NullableSingleLogFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleLogFunctionExpression Log(NullableSingleElement element, AnyElement<int> @base)
            => new(element, @base);
    }
}
