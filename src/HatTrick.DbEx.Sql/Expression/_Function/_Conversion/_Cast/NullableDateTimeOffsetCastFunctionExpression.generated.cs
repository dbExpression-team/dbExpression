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
    public partial class NullableDateTimeOffsetCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDateTimeOffsetExpressionMediator(NullableDateTimeOffsetCastFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool



        
        #endregion
        
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region DateTime
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTime a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTime a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTime? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTime? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region Guid



        
        #endregion
        
        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        
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
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTime
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region Guid

        #endregion        
        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region string?

        #endregion        
        #region TimeSpan

        #endregion        
        #endregion

        #region mediator
        #region bool

        #endregion
        
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTime
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region Guid

        #endregion
        
        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region string?

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator +(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region DateTimeOffset
        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset? a, NullableDateTimeOffsetCastFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeOffsetCastFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
