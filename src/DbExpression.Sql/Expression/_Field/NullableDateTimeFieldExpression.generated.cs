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
using System.Collections.Generic;

#nullable disable

namespace DbExpression.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableDateTimeFieldExpression
    {
        #region implicit operators
        public static implicit operator NullableDateTimeExpressionMediator(NullableDateTimeFieldExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(byte a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(byte a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(byte? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(byte? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(decimal a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(decimal a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(decimal? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(decimal? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(double a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(double a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(double? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(double? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(float a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(float a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(float? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(float? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(short a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(short a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(short? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(short? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(int a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(int a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(int? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(int? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(long a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(long a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(long? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(long? a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        

        #region string
        #endregion        

        #region TimeSpan
        #endregion        

        #endregion

        #region fields
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion



        #endregion

        #region mediators
        #region byte
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, ByteExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, ByteExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableByteExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableByteExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion

        #region decimal
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DecimalExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DecimalExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDecimalExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDecimalExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion

        #region DateTime
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b)
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
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion

        #region double
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DoubleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DoubleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDoubleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDoubleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion

        #region float
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, SingleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, SingleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableSingleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableSingleExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion

        #region short
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int16ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int16ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt16ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt16ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion

        #region int
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int32ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int32ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt32ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt32ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion

        #region long
        //here
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int64ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        //here
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int64ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt64ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt64ExpressionMediator b)
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }
        #endregion



        #endregion

        #region alias
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, NullElement b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, NullElement b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region DateTime
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b, a), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b, a), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b, a), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b, a), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b, a), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b, a), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b, a), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b, a), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b, a), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffset a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffset a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffset a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffset a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffset a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffset a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b, a), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b, a), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b, a), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b, a), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        #region DateTime
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region mediators
        #region DateTime
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
