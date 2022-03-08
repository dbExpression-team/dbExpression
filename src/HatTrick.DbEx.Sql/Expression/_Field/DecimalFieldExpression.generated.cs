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
using System.Collections.Generic;

#nullable enable

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalFieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params decimal[] value) => new(new FilterExpression<bool>(this, new InExpression<decimal>(this, value), FilterExpressionOperator.None));
        public override FilterExpressionSet In(IEnumerable<decimal> value) => new(new FilterExpression<bool>(this, new InExpression<decimal>(this, value), FilterExpressionOperator.None));
        #endregion

        #region implicit operators
        public static implicit operator DecimalExpressionMediator(DecimalFieldExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(byte a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(byte a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(byte a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(byte a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(byte a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(byte? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(byte? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(byte? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(byte? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(byte? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(DecimalFieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DecimalFieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DecimalFieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DecimalFieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DecimalFieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DecimalFieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DecimalFieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DecimalFieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(double a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(double a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(double a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(double a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(double a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(double? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(double? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(double? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(double? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(double? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(float a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(float a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(float a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(float a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(float a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(float? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(float? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(float? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(float? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(float? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(short a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(short a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(short a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(short a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(short a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(short? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(short? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(short? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(short? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(short? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(int a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(int a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(int a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(int a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(int a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(int? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(int? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(int? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(int? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(int? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(long a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(long a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(long a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(long a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(long a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(long? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(long? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(long? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(long? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(long? a, DecimalFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?


        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields
        #region byte
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(DecimalFieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DecimalFieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DecimalFieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DecimalFieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DecimalFieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DecimalFieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DecimalFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DecimalFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region mediators
        #region byte
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(DecimalFieldExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DecimalFieldExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DecimalFieldExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DecimalFieldExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DecimalFieldExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DecimalFieldExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DecimalFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DecimalFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DecimalFieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DecimalFieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DecimalFieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DecimalFieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DecimalFieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(DecimalFieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DecimalFieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(DecimalFieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(DecimalFieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(DecimalFieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        public static ObjectExpressionMediator operator +(DecimalFieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableAlias, b.FieldAlias), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DecimalFieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableAlias, b.FieldAlias), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(DecimalFieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableAlias, b.FieldAlias), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(DecimalFieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableAlias, b.FieldAlias), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(DecimalFieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableAlias, b.FieldAlias), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(DecimalFieldExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region decimal
        public static FilterExpressionSet operator ==(DecimalFieldExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b, a), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b, a), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b, a), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b, a), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(decimal a, DecimalFieldExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(decimal a, DecimalFieldExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a, b), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(decimal a, DecimalFieldExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a, b), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(decimal a, DecimalFieldExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a, b), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(decimal a, DecimalFieldExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a, b), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(decimal a, DecimalFieldExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DecimalFieldExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b, a), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(decimal? a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(decimal? a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(decimal? a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(decimal? a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(decimal? a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(decimal? a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(DecimalFieldExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(DecimalFieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(DecimalFieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DecimalFieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DecimalFieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DecimalFieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DecimalFieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DecimalFieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
