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

using System;

#nullable enable

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetIsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetIsNullFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool



        #endregion
        
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(byte a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(byte a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(decimal a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(decimal a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTime a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTime a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTime? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTime? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(double a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(double a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(float a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(float a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region Guid



        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(short a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(short a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(int a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(int a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(long a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(long a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, DateTimeOffsetIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region string?



        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields
        #region bool

        #endregion        
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region Guid

        #endregion        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region string?

        #endregion        
        #region TimeSpan

        #endregion        
        #endregion

        #region mediators
        #region bool

        #endregion        
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region Guid

        #endregion        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region string?

        #endregion        
        #region TimeSpan

        #endregion        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region DateTimeOffset
        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
