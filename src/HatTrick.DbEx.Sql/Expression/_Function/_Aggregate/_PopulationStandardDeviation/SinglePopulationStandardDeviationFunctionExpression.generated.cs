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
    public partial class SinglePopulationStandardDeviationFunctionExpression
    {
        #region implicit operators
        public static implicit operator SingleExpressionMediator(SinglePopulationStandardDeviationFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(byte a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(byte a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(byte a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(byte a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(byte a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(decimal a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(decimal a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(decimal a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(decimal a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(decimal a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(decimal? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(decimal? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(decimal? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(decimal? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(decimal? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region double
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(double a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(double a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(double a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(double a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(double a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(double? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(double? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(double? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(double? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(double? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(short a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(short a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(short a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(short a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(short a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(int a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(int a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(int a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(int a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(int a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(long a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(long a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(long a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(long a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(long a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region mediators
        #region byte
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static SingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        public static ObjectExpressionMediator operator +(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region float
        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float? a, SinglePopulationStandardDeviationFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SinglePopulationStandardDeviationFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
