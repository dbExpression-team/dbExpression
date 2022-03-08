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
    public partial class NullableDateTimeMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDateTimeExpressionMediator(NullableDateTimeMinimumFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(byte a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(byte a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(byte? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(byte? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(decimal a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(decimal a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(decimal? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(decimal? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(double a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(double a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(double? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(double? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(float a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(float a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(float? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(float? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(short a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(short a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(short? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(short? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(int a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(int a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(int? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(int? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(long a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(long a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(long? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(long? a, NullableDateTimeMinimumFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region DateTime
        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, DateTime b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, DateTime b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, DateTime b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, DateTime b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, DateTime b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, DateTime b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTime a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTime a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTime a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime? a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime? a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime? a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTime? a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTime? a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTime? a, NullableDateTimeMinimumFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(NullableDateTimeMinimumFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeMinimumFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeMinimumFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDateTimeMinimumFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDateTimeMinimumFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDateTimeMinimumFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
