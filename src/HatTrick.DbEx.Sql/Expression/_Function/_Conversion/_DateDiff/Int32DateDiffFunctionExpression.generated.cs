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
    public partial class Int32DateDiffFunctionExpression
    {
        #region implicit operators
        public static implicit operator Int32ExpressionMediator(Int32DateDiffFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(byte a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(byte a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(byte a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(byte a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(byte a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int32DateDiffFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32DateDiffFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32DateDiffFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32DateDiffFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32DateDiffFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32DateDiffFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32DateDiffFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32DateDiffFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32DateDiffFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32DateDiffFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int32DateDiffFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32DateDiffFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32DateDiffFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32DateDiffFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32DateDiffFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32DateDiffFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32DateDiffFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32DateDiffFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32DateDiffFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32DateDiffFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int32DateDiffFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32DateDiffFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32DateDiffFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32DateDiffFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32DateDiffFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32DateDiffFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32DateDiffFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32DateDiffFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32DateDiffFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32DateDiffFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(short a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(short a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(short a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(short a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(short a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(int a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(int a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(int a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(int a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(int a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int32DateDiffFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32DateDiffFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32DateDiffFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32DateDiffFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32DateDiffFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32DateDiffFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32DateDiffFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32DateDiffFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32DateDiffFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32DateDiffFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, Int32DateDiffFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static DecimalExpressionMediator operator +(Int32DateDiffFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32DateDiffFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32DateDiffFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32DateDiffFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32DateDiffFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static DoubleExpressionMediator operator +(Int32DateDiffFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32DateDiffFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32DateDiffFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32DateDiffFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32DateDiffFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static SingleExpressionMediator operator +(Int32DateDiffFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32DateDiffFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32DateDiffFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32DateDiffFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32DateDiffFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static Int64ExpressionMediator operator +(Int32DateDiffFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32DateDiffFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32DateDiffFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32DateDiffFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32DateDiffFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region mediators
        #region byte
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static DecimalExpressionMediator operator +(Int32DateDiffFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32DateDiffFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32DateDiffFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32DateDiffFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32DateDiffFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static DoubleExpressionMediator operator +(Int32DateDiffFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32DateDiffFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32DateDiffFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32DateDiffFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32DateDiffFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static SingleExpressionMediator operator +(Int32DateDiffFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32DateDiffFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32DateDiffFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32DateDiffFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32DateDiffFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static Int32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static Int64ExpressionMediator operator +(Int32DateDiffFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32DateDiffFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32DateDiffFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32DateDiffFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32DateDiffFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32DateDiffFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32DateDiffFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32DateDiffFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32DateDiffFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32DateDiffFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        public static ObjectExpressionMediator operator +(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region int
        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(int a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(int a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(int a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(int a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(int a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(int a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(int? a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(int? a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(int? a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(int? a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(int? a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(int? a, Int32DateDiffFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(Int32DateDiffFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
