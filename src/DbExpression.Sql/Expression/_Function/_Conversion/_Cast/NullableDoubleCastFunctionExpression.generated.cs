#region license
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

using System;
using DbExpression.Sql;

#nullable disable

namespace DbExpression.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableDoubleCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDoubleExpressionMediator(NullableDoubleCastFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool
        
        #endregion
        
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(byte a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(byte a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(byte a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(byte a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(byte a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(byte? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(byte? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(byte? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(byte? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(byte? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleCastFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleCastFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleCastFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleCastFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleCastFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(decimal a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(NullableDoubleCastFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleCastFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleCastFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleCastFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleCastFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(double a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(double a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(double a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(double a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(double a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(double? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(double? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(double? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(double? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(double? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(float a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(float a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(float a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(float a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(float a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(float? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(float? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(float? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(float? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(float? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region Guid
        
        #endregion
        
        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(short a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(short a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(short a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(short a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(short a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(short? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(short? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(short? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(short? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(short? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(int a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(int a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(int a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(int a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(int a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(int? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(int? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(int? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(int? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(int? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(long a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(long a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(long a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(long a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(long a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(long? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(long? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(long? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(long? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(long? a, NullableDoubleCastFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region string
        
        #endregion
        
        #region TimeSpan
        
        #endregion
        
        #endregion

        #region fields
        #region bool
        #endregion

        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region Guid
        #endregion

        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region string
        #endregion

        #region TimeSpan
        #endregion

        #endregion

        #region mediator
        #region bool
        #endregion
        
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region Guid
        #endregion
        
        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region string
        #endregion
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region alias
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region byte
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(byte a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(byte a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(byte a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(byte a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(byte a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(byte a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(byte? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(byte? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(byte? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(byte? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(byte? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(byte? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(decimal a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(decimal a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(decimal a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(decimal a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(decimal a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(decimal a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(decimal? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(decimal? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(decimal? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(decimal? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(decimal? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(decimal? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(double a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(double a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(double a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(double a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(double a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(double a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(double? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(double? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(double? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(double? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(double? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(double? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(float a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(float a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(float a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(float a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(float a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(float a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(float? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(float? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(float? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(float? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(float? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(float? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(short a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(short a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(short a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(short a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(short a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(short a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(short? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(short? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(short? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(short? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(short? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(short? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(int a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(int a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(int a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(int a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(int a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(int a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(int? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(int? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(int? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(int? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(int? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(int? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(long a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(long a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(long a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(long a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(long a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(long a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(long? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(long? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(long? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(long? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(long? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(long? a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        #region byte
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region mediators
        #region byte
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDoubleCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, NullableDoubleCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #endregion
    }
}
