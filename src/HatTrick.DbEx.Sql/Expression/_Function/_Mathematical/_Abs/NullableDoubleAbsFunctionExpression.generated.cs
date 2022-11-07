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
using HatTrick.DbEx.Sql;

#nullable enable

namespace HatTrick.DbEx.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableDoubleAbsFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDoubleExpressionMediator(NullableDoubleAbsFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(byte a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(byte a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(byte a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(byte a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(byte a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(byte? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(byte? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(byte? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(byte? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(byte? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(decimal a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(double a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(double a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(double a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(double a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(double a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(double? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(double? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(double? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(double? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(double? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(float a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(float a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(float a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(float a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(float a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(float? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(float? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(float? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(float? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(float? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(short a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(short a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(short a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(short a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(short a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(short? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(short? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(short? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(short? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(short? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(int a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(int a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(int a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(int a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(int a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(int? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(int? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(int? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(int? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(int? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(long a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(long a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(long a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(long a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(long a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(long? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(long? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(long? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(long? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(long? a, NullableDoubleAbsFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDecimalExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDecimalExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDecimalExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDecimalExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDecimalExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region float
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region int
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region long
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) 
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
        public static NullableDecimalExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) 
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
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region short
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) 
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
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) 
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
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #endregion

        #region alias
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableDoubleExpressionMediator operator +(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDoubleExpressionMediator operator -(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDoubleExpressionMediator operator *(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableDoubleExpressionMediator operator /(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableDoubleExpressionMediator operator %(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<double?>(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region byte
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(byte a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(byte a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(byte a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(byte a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(byte a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(byte a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(byte? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(byte? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(byte? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(byte? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(byte? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(byte? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(decimal a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(decimal a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(decimal a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(decimal a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(decimal a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(decimal a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(decimal? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(decimal? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(decimal? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(decimal? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(decimal? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(decimal? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(double a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(double a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(double a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(double a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(double a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(double a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(double? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(double? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(double? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(double? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(double? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(double? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(float a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(float a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(float a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(float a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(float a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(float a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(float? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(float? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(float? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(float? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(float? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(float? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(short a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(short a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(short a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(short a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(short a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(short a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(short? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(short? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(short? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(short? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(short? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(short? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(int a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(int a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(int a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(int a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(int a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(int a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(int? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(int? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(int? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(int? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(int? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(int? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(long a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(long a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(long a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(long a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(long a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(long a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(long? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(long? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(long? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(long? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(long? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(long? a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        #region byte
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region mediators
        #region byte
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDoubleAbsFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, NullableDoubleAbsFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<double?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #endregion
    }
}
