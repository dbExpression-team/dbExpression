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
    public partial class NullableDoubleExpressionMediator
    {
        #region arithmetic operators 
        #region data type 
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(byte a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(byte a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(byte a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(byte a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(byte a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(byte? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(byte? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(byte? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(byte? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(byte? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleExpressionMediator a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDoubleExpressionMediator a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDoubleExpressionMediator a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDoubleExpressionMediator a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDoubleExpressionMediator a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDoubleExpressionMediator a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDoubleExpressionMediator a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDoubleExpressionMediator a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDoubleExpressionMediator a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDoubleExpressionMediator a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(float a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(float a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(float a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(float a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(float a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(float? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(float? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(float? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(float? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(float? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(short a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(short a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(short a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(short a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(short a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(short? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(short? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(short? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(short? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(short? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(int a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(int a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(int a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(int a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(int a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(int? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(int? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(int? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(int? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(int? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(long a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(long a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(long a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(long a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(long a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(long? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(long? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(long? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(long? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(long? a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion


        #region TimeSpan



        #endregion

        #endregion

        #region fields
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleExpressionMediator a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDoubleExpressionMediator a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDoubleExpressionMediator a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDoubleExpressionMediator a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDoubleExpressionMediator a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string?

        #endregion

        #region TimeSpan

        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleExpressionMediator a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDoubleExpressionMediator a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDoubleExpressionMediator a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDoubleExpressionMediator a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDoubleExpressionMediator a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion


        #region TimeSpan

        #endregion

        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableDoubleExpressionMediator a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableDoubleExpressionMediator a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableDoubleExpressionMediator a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableDoubleExpressionMediator a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableDoubleExpressionMediator a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, DBNull b) => new(new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<double?>(b, field) : new LiteralExpression<double?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, DBNull b) => new(new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<double?>(b, field) : new LiteralExpression<double?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b.Expression is FieldExpression field ? new LiteralExpression<double?>(a, field) : new LiteralExpression<double?>(a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b.Expression is FieldExpression field ? new LiteralExpression<double?>(a, field) : new LiteralExpression<double?>(a), FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region double
        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, double b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, double b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, double b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, double b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, double b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, double b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(double a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(double a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(double a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(double a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(double a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(double a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(double? a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(double? a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(double? a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(double? a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(double? a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(double? a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields

        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));

        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));

        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));

        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));

        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, DoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));


        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));

        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));

        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));

        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));

        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, DoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(NullableDoubleExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
