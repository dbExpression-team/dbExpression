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

using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class VersionBaseMsSqlFunctionExpressionBuilder
    {
        #region decimal
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>.</returns>
        public virtual DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>.</returns>
        public virtual DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>.</returns>
        public virtual DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>.</returns>
        public virtual DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>.</returns>
        public virtual DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>.</returns>
        public virtual DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableNumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableNumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length, NullableNumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableNumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NumericElement length, NullableNumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public virtual NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableNumericElement length, NullableNumericElement function)
            => new(expression, length, function);
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>.</returns>
        public virtual DoubleRoundFunctionExpression Round(AnyElement<double> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>.</returns>
        public virtual DoubleRoundFunctionExpression Round(AnyElement<double> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>.</returns>
        public virtual DoubleRoundFunctionExpression Round(AnyElement<double> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>.</returns>
        public virtual DoubleRoundFunctionExpression Round(AnyElement<double> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>.</returns>
        public virtual DoubleRoundFunctionExpression Round(AnyElement<double> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>.</returns>
        public virtual DoubleRoundFunctionExpression Round(AnyElement<double> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableNumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableNumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length, NullableNumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableNumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NumericElement length, NullableNumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public virtual NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableNumericElement length, NullableNumericElement function)
            => new(expression, length, function);
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{byte}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<byte> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{byte}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<byte> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{byte}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<byte> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{byte}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<byte> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{byte}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<byte> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{byte}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<byte> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NullableNumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NullableNumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, int length, NullableNumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NullableNumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NumericElement length, NullableNumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<byte?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<byte?> expression, NullableNumericElement length, NullableNumericElement function)
            => new(expression, length, function);
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<short> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<short> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<short> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<short> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<short> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<short> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NullableNumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NullableNumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, int length, NullableNumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NullableNumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NumericElement length, NullableNumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<short?> expression, NullableNumericElement length, NullableNumericElement function)
            => new(expression, length, function);
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<int> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<int> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<int> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<int> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<int> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>.</returns>
        public virtual Int32RoundFunctionExpression Round(AnyElement<int> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableNumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableNumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length, NullableNumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableNumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NumericElement length, NullableNumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public virtual NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableNumericElement length, NullableNumericElement function)
            => new(expression, length, function);
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>.</returns>
        public virtual Int64RoundFunctionExpression Round(AnyElement<long> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>.</returns>
        public virtual Int64RoundFunctionExpression Round(AnyElement<long> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>.</returns>
        public virtual Int64RoundFunctionExpression Round(AnyElement<long> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>.</returns>
        public virtual Int64RoundFunctionExpression Round(AnyElement<long> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>.</returns>
        public virtual Int64RoundFunctionExpression Round(AnyElement<long> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>.</returns>
        public virtual Int64RoundFunctionExpression Round(AnyElement<long> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableNumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableNumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length, NullableNumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableNumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NumericElement length, NullableNumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public virtual NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableNumericElement length, NullableNumericElement function)
            => new(expression, length, function);
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>.</returns>
        public virtual SingleRoundFunctionExpression Round(AnyElement<float> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>.</returns>
        public virtual SingleRoundFunctionExpression Round(AnyElement<float> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>.</returns>
        public virtual SingleRoundFunctionExpression Round(AnyElement<float> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>.</returns>
        public virtual SingleRoundFunctionExpression Round(AnyElement<float> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>.</returns>
        public virtual SingleRoundFunctionExpression Round(AnyElement<float> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>.</returns>
        public virtual SingleRoundFunctionExpression Round(AnyElement<float> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length)
            => new(expression, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length, int function)
            => new(expression, new LiteralExpression<int>(length), new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableNumericElement length)
            => new(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableNumericElement length, int function)
            => new(expression, length, new LiteralExpression<int>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length, NumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length, NullableNumericElement function)
            => new(expression, new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableNumericElement length, NumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NumericElement length, NullableNumericElement function)
            => new(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round?version=0.9.5">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public virtual NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableNumericElement length, NullableNumericElement function)
            => new(expression, length, function);
        #endregion
    }
}
