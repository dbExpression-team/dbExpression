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
    public partial class Int32FieldExpression
    {
        #region in value set
        public override FilterExpression In(params int[] value) => new FilterExpression<bool>(this, new InExpression<int>(this, value), FilterExpressionOperator.None);
        public override FilterExpression In(IEnumerable<int> value) => new FilterExpression<bool>(this, new InExpression<int>(this, value), FilterExpressionOperator.None);
        #endregion

        #region implicit operators
        public static implicit operator Int32ExpressionMediator(Int32FieldExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b, a), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(byte a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(byte a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(byte a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(byte a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(byte a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32FieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32FieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int32FieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int32FieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b, a), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int32FieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int32FieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int32FieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int32FieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b, a), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a, b), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int32FieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int32FieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b, a), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32FieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b, a), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32FieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32FieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b, a), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32FieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b, a), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(short a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(short a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(short a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(short a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(short a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b, a), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(int a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(int a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(int a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(int a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(int a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32FieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b, a), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a, b), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32FieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b, a), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, Int32FieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a, b), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?


        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields
        #region byte
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32FieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32FieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int32FieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int32FieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int32FieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int32FieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int32FieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int32FieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int32FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int32FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32FieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32FieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32FieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32FieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32FieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32FieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region mediators
        #region byte
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32FieldExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32FieldExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int32FieldExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int32FieldExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int32FieldExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int32FieldExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int32FieldExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int32FieldExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int32FieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int32FieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32FieldExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32FieldExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32FieldExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32FieldExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32FieldExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32FieldExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region alias
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, (string TableAlias, string FieldAlias) b) => new(new ArithmeticExpression(a, new AliasExpression<int?>(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression operator ==(Int32FieldExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(DBNull a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DBNull a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region int
        public static FilterExpression operator ==(Int32FieldExpression a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b, a), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(int a, Int32FieldExpression b) => new FilterExpression<bool>(new LiteralExpression<int>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(int a, Int32FieldExpression b) => new FilterExpression<bool>(new LiteralExpression<int>(a, b), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(int a, Int32FieldExpression b) => new FilterExpression<bool>(new LiteralExpression<int>(a, b), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(int a, Int32FieldExpression b) => new FilterExpression<bool>(new LiteralExpression<int>(a, b), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(int a, Int32FieldExpression b) => new FilterExpression<bool>(new LiteralExpression<int>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(int a, Int32FieldExpression b) => new FilterExpression<bool>(new LiteralExpression<int>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(Int32FieldExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b, a), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(int? a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(int? a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(int? a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(int? a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(int? a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(int? a, Int32FieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region fields
        public static FilterExpression operator ==(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediators
        public static FilterExpression operator ==(Int32FieldExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(Int32FieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(Int32FieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<int>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Int32FieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<int>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(Int32FieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<int>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(Int32FieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<int>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(Int32FieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<int>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(Int32FieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
