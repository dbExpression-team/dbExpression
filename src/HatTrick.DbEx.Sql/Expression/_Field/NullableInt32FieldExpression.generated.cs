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
    public partial class NullableInt32FieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params int?[] value) => new(new FilterExpression<bool?>(this, new InExpression<int?>(this, value), FilterExpressionOperator.None));
        public override FilterExpressionSet In(IEnumerable<int?> value) => new(new FilterExpression<bool?>(this, new InExpression<int?>(this, value), FilterExpressionOperator.None));
        #endregion

        #region implicit operators
        public static implicit operator NullableInt32ExpressionMediator(NullableInt32FieldExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt32FieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32FieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt32FieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32FieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion        

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32FieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32FieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32FieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32FieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion        

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region string?


        #endregion        

        #region TimeSpan



        #endregion        

        #endregion

        #region fields
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt32FieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32FieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt32FieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32FieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32FieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32FieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion



        #endregion

        #region mediators
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt32FieldExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32FieldExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt32FieldExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32FieldExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32FieldExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32FieldExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32FieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32FieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion



        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableInt32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableInt32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableInt32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableInt32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableInt32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        public static ObjectExpressionMediator operator +(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region int
        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, int b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, int b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, int b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, int b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, int b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, int b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(int a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(int a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(int a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(int a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(int a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(int a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(int? a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(int? a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(int? a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(int? a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(int? a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(int? a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, Int32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt32FieldExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
