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
    public partial class NullableDecimalIsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDecimalExpressionMediator(NullableDecimalIsNullFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool



        
        #endregion
        
        #region byte
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(byte a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(byte a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(byte a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(byte a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(byte a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(byte? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(byte? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(byte? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(byte? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(byte? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region double
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(double a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(double a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(double a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(double a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(double a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(double? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(double? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(double? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(double? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(double? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region float
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(float a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(float a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(float a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(float a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(float a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(float? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(float? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(float? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(float? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(float? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region Guid



        
        #endregion
        
        #region short
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(short a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(short a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(short a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(short a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(short a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(short? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(short? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(short? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(short? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(short? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region int
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(int a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(int a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(int a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(int a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(int a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(int? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(int? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(int? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(int? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(int? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region long
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(long a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(long a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(long a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(long a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(long a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(long? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(long? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(long? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(long? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(long? a, NullableDecimalIsNullFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        
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
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region double
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region Guid

        #endregion        
        #region short
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
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
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region Guid

        #endregion
        
        #region short
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        public static ObjectExpressionMediator operator +(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region decimal
        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, decimal b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(decimal a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(decimal? a, NullableDecimalIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDecimalIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
