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

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64FieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params long[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<long>(this, value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<long> value) => value is object ? new FilterExpression<bool>(this, new InExpression<long>(this, value), FilterExpressionOperator.None) : null;
        public override FilterExpressionSet In(params long?[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<long?>(this, value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<long?> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<long?>(this, value), FilterExpressionOperator.None)) : null;
        #endregion

        #region implicit operators
        public static implicit operator NullableInt64ExpressionMediator(NullableInt64FieldExpression a) => new NullableInt64ExpressionMediator(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(byte a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(byte a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(byte a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(byte a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(byte a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(byte? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(byte? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(byte? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(byte? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(byte? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64FieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64FieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64FieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64FieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64FieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableInt64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64FieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64FieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt64FieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64FieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion        

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64FieldExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64FieldExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64FieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64FieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion        

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64FieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64FieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64FieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64FieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64FieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableInt64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64FieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64FieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64FieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64FieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64FieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(short a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(short a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(short a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(short a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(short a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(short? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(short? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(short? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(short? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(short? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(int a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(int a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(int a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(int a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(int a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(int? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(int? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(int? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(int? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(int? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion        

        #region string


        #endregion        

        #region TimeSpan



        #endregion        

        #endregion

        #region fields
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64FieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64FieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64FieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64FieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64FieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64FieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64FieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt64FieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64FieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64FieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64FieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64FieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64FieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64FieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64FieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64FieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64FieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64FieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64FieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64FieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64FieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion



        #endregion

        #region mediators
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64FieldExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64FieldExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64FieldExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64FieldExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64FieldExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt64FieldExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64FieldExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64FieldExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64FieldExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64FieldExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64FieldExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64FieldExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt64FieldExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64FieldExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64FieldExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64FieldExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64FieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64FieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64FieldExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64FieldExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64FieldExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64FieldExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64FieldExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt64FieldExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64FieldExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64FieldExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64FieldExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64FieldExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64FieldExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64FieldExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64FieldExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64FieldExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64FieldExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt64FieldExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64FieldExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64FieldExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64FieldExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64FieldExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion



        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableInt64FieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableInt64FieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableInt64FieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableInt64FieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableInt64FieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region long
        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64FieldExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b, a), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64FieldExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b, a), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64FieldExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b, a), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64FieldExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b, a), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(long a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(long a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(long a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64FieldExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64FieldExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64FieldExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64FieldExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b, a), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long? a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long? a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long? a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(long? a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(long? a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(long? a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64FieldExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableInt64FieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64FieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64FieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64FieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64FieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64FieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
