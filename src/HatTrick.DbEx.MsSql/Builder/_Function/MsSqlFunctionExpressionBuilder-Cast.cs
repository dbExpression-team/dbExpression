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
    public partial class MsSqlFunctionExpressionBuilder
    {
        #region object
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="ObjectElement{{T}}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast<T>(ObjectElement<T> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableObjectElement{{T}}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast<T>(NullableObjectElement<T> element)
            => new MsSqlCastFunctionExpressionBuilder(element);
        #endregion

        #region bool
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Boolean}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<bool> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Boolean}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<bool?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Byte}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<byte> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Byte}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<byte?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region DateTime
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<DateTime> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<DateTime?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<DateTimeOffset> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<DateTimeOffset?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Decimal}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<decimal> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Decimal}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<decimal?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Double}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<double> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Double}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<double?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region enum
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="EnumElement{TEnum}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableEnumElement{TEnum}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Single}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<float> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Single}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<float?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region Guid
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Guid}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<Guid> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Guid}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<Guid?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Int16}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<short> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Int16}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<short?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Int32}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<int> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Int32}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<int?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Int64}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<long> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{Int64}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<long?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{String}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<string> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableStringElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableStringElement element)
            => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region TimeSpan
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{TimeSpan}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static MsSqlCast Cast(AnyElement<TimeSpan> element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyElement{TimeSpan}"/>? to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(AnyElement<TimeSpan?> element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion
    }
}
