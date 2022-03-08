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
    public partial class AliasExpression
    {
        #region order
        public OrderByExpression Asc => new(this, OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new(this, OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(AliasExpression a) => new(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(AliasExpression a) => new(a);
        public static implicit operator ObjectExpressionMediator(AliasExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool



        #endregion
        
        #region byte
        public static ObjectExpressionMediator operator +(AliasExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, byte b) => new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(byte a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(byte a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(byte a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(byte a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(byte a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, byte? b) => new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(byte? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(byte? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(byte? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(byte? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(byte? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static ObjectExpressionMediator operator +(AliasExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, decimal b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(decimal a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(decimal a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(decimal a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(decimal a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(decimal a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, decimal? b) => new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(decimal? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(decimal? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(decimal? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(decimal? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(decimal? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static ObjectExpressionMediator operator +(AliasExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(DateTime a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DateTime a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(AliasExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(DateTime? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DateTime? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static ObjectExpressionMediator operator +(AliasExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(DateTimeOffset a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DateTimeOffset a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(AliasExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(DateTimeOffset? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DateTimeOffset? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static ObjectExpressionMediator operator +(AliasExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, double b) => new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(double a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(double a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(double a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(double a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(double a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, double? b) => new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(double? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(double? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(double? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(double? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(double? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static ObjectExpressionMediator operator +(AliasExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(float a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(float a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(float a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(float a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(float a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(float? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(float? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(float? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(float? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(float? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region Guid



        #endregion
        
        #region short
        public static ObjectExpressionMediator operator +(AliasExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, short b) => new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(short a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(short a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(short a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(short a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(short a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, short? b) => new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(short? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(short? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(short? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(short? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(short? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static ObjectExpressionMediator operator +(AliasExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, int b) => new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(int a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(int a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(int a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(int a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(int a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, int? b) => new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(int? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(int? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(int? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(int? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(int? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static ObjectExpressionMediator operator +(AliasExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, long b) => new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(long a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(long a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(long a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(long a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(long a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, long? b) => new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(long? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(long? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(long? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(long? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(long? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?
        public static ObjectExpressionMediator operator +(AliasExpression a, string? b) => new(new ArithmeticExpression(a, new LiteralExpression<string?>(b), ArithmeticExpressionOperator.Add));

        public static ObjectExpressionMediator operator +(string? a, AliasExpression b) => new(new ArithmeticExpression(new LiteralExpression<string?>(a), b, ArithmeticExpressionOperator.Add));

        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields
        #region bool

        #endregion
        
        #region byte
        public static ObjectExpressionMediator operator +(AliasExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, ByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableByteFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static ObjectExpressionMediator operator +(AliasExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, DecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableDecimalFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static ObjectExpressionMediator operator +(AliasExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static ObjectExpressionMediator operator +(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static ObjectExpressionMediator operator +(AliasExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, DoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableDoubleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static ObjectExpressionMediator operator +(AliasExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region Guid

        #endregion
        
        #region short
        public static ObjectExpressionMediator operator +(AliasExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, Int16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableInt16FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static ObjectExpressionMediator operator +(AliasExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, Int32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableInt32FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static ObjectExpressionMediator operator +(AliasExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, Int64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableInt64FieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?
        public static ObjectExpressionMediator operator +(AliasExpression a, StringFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region mediators
        #region bool

        #endregion
        
        #region byte
        public static ObjectExpressionMediator operator +(AliasExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, ByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableByteExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static ObjectExpressionMediator operator +(AliasExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, DecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableDecimalExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static ObjectExpressionMediator operator +(AliasExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static ObjectExpressionMediator operator +(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static ObjectExpressionMediator operator +(AliasExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, DoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableDoubleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static ObjectExpressionMediator operator +(AliasExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, SingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableSingleExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region Guid

        #endregion
        
        #region short
        public static ObjectExpressionMediator operator +(AliasExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, Int16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableInt16ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static ObjectExpressionMediator operator +(AliasExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, Int32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableInt32ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static ObjectExpressionMediator operator +(AliasExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, Int64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, NullableInt64ExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string?
        public static ObjectExpressionMediator operator +(AliasExpression a, StringExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(AliasExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +(AliasExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression(b.TableName, b.FieldName), ArithmeticExpressionOperator.Modulo));

        public static ObjectExpressionMediator operator +((string TableName, string FieldName) a, AliasExpression b) => new(new ArithmeticExpression(new AliasExpression(a.TableName, a.FieldName), b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -((string TableName, string FieldName) a, AliasExpression b) => new(new ArithmeticExpression(new AliasExpression(a.TableName, a.FieldName), b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *((string TableName, string FieldName) a, AliasExpression b) => new(new ArithmeticExpression(new AliasExpression(a.TableName, a.FieldName), b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /((string TableName, string FieldName) a, AliasExpression b) => new(new ArithmeticExpression(new AliasExpression(a.TableName, a.FieldName), b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %((string TableName, string FieldName) a, AliasExpression b) => new(new ArithmeticExpression(new AliasExpression(a.TableName, a.FieldName), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(AliasExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<object>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<object>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<object>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<object>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region bool
        public static FilterExpressionSet operator ==(AliasExpression a, bool b) => new(new FilterExpression<bool>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, bool b) => new(new FilterExpression<bool>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(bool a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, bool? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, bool? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(bool? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region byte
        public static FilterExpressionSet operator ==(AliasExpression a, byte b) => new(new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, byte b) => new(new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, byte b) => new(new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, byte b) => new(new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, byte b) => new(new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, byte b) => new(new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(byte a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(byte a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(byte a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(byte a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(byte a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(byte a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, byte? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, byte? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, byte? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, byte? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, byte? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, byte? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(byte? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(byte? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(byte? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(byte? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(byte? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(byte? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region decimal
        public static FilterExpressionSet operator ==(AliasExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, decimal b) => new(new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(decimal a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(decimal a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(decimal a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(decimal a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(decimal a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(decimal a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, decimal? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(decimal? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(decimal? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(decimal? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(decimal? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(decimal? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(decimal? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region DateTime
        public static FilterExpressionSet operator ==(AliasExpression a, DateTime b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTime b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTime b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTime b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTime b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTime b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTime a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTime a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTime a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTime? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTime? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTime? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTime? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region DateTimeOffset
        public static FilterExpressionSet operator ==(AliasExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTimeOffset? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region double
        public static FilterExpressionSet operator ==(AliasExpression a, double b) => new(new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, double b) => new(new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, double b) => new(new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, double b) => new(new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, double b) => new(new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, double b) => new(new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(double a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(double a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(double a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(double a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(double a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(double a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, double? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(double? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(double? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(double? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(double? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(double? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(double? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region float
        public static FilterExpressionSet operator ==(AliasExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, float b) => new(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, float? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region Guid
        public static FilterExpressionSet operator ==(AliasExpression a, Guid b) => new(new FilterExpression<bool>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Guid b) => new(new FilterExpression<bool>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, Guid? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Guid? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region short
        public static FilterExpressionSet operator ==(AliasExpression a, short b) => new(new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, short b) => new(new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, short b) => new(new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, short b) => new(new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, short b) => new(new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, short b) => new(new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(short a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(short a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(short a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, short? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, short? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, short? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, short? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, short? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, short? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(short? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(short? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(short? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region int
        public static FilterExpressionSet operator ==(AliasExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, int b) => new(new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(int a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(int a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(int a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(int a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(int a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(int a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, int? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(int? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(int? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(int? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(int? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(int? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(int? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region long
        public static FilterExpressionSet operator ==(AliasExpression a, long b) => new(new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, long b) => new(new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, long b) => new(new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, long b) => new(new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, long b) => new(new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, long b) => new(new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(long a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(long a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(long a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, long? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, long? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, long? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, long? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, long? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, long? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(long? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(long? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(long? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region string?
        public static FilterExpressionSet operator ==(AliasExpression a, string? b) => new(new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, string? b) => new(new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, string? b) => new(new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, string? b) => new(new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, string? b) => new(new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, string? b) => new(new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(string? a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(string? a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(string? a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(string? a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(string? a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(string? a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region TimeSpan
        public static FilterExpressionSet operator ==(AliasExpression a, TimeSpan b) => new(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, TimeSpan b) => new(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, TimeSpan b) => new(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, TimeSpan b) => new(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, TimeSpan b) => new(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, TimeSpan b) => new(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpan a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpan a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpan a, AliasExpression b) => new(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, TimeSpan? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, TimeSpan? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, TimeSpan? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, TimeSpan? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, TimeSpan? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, TimeSpan? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpan? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpan? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpan? a, AliasExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region object?
        #endregion

        #endregion
        

        #region fields
        #region bool
        public static FilterExpressionSet operator ==(AliasExpression a, BooleanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, BooleanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableBooleanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableBooleanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region byte
        public static FilterExpressionSet operator ==(AliasExpression a, ByteFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, ByteFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, ByteFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, ByteFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, ByteFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, ByteFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableByteFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableByteFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableByteFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableByteFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableByteFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableByteFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region decimal
        public static FilterExpressionSet operator ==(AliasExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DecimalFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDecimalFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region DateTime
        public static FilterExpressionSet operator ==(AliasExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTimeFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDateTimeFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region DateTimeOffset
        public static FilterExpressionSet operator ==(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTimeOffsetFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region double
        public static FilterExpressionSet operator ==(AliasExpression a, DoubleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DoubleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DoubleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DoubleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DoubleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DoubleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDoubleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region float
        public static FilterExpressionSet operator ==(AliasExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, SingleFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableSingleFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region Guid
        public static FilterExpressionSet operator ==(AliasExpression a, GuidFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, GuidFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableGuidFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableGuidFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region short
        public static FilterExpressionSet operator ==(AliasExpression a, Int16FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Int16FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, Int16FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, Int16FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, Int16FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, Int16FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableInt16FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableInt16FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableInt16FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableInt16FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableInt16FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableInt16FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region int
        public static FilterExpressionSet operator ==(AliasExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, Int32FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableInt32FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region long
        public static FilterExpressionSet operator ==(AliasExpression a, Int64FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Int64FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, Int64FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, Int64FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, Int64FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, Int64FieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableInt64FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableInt64FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableInt64FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableInt64FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableInt64FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableInt64FieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region string?
        public static FilterExpressionSet operator ==(AliasExpression a, StringFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, StringFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, StringFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, StringFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, StringFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, StringFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region TimeSpan
        public static FilterExpressionSet operator ==(AliasExpression a, TimeSpanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, TimeSpanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, TimeSpanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, TimeSpanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, TimeSpanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, TimeSpanFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableTimeSpanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableTimeSpanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableTimeSpanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableTimeSpanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableTimeSpanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableTimeSpanFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region object?
        #endregion


        #endregion
        
        #region mediators
        #region bool
        public static FilterExpressionSet operator ==(AliasExpression a, BooleanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, BooleanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableBooleanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableBooleanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region byte
        public static FilterExpressionSet operator ==(AliasExpression a, ByteExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, ByteExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, ByteExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, ByteExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, ByteExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, ByteExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableByteExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableByteExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableByteExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableByteExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableByteExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableByteExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region decimal
        public static FilterExpressionSet operator ==(AliasExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DecimalExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDecimalExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region DateTime
        public static FilterExpressionSet operator ==(AliasExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTimeExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDateTimeExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region DateTimeOffset
        public static FilterExpressionSet operator ==(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region double
        public static FilterExpressionSet operator ==(AliasExpression a, DoubleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, DoubleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, DoubleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, DoubleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, DoubleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, DoubleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableDoubleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region float
        public static FilterExpressionSet operator ==(AliasExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, SingleExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableSingleExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region Guid
        public static FilterExpressionSet operator ==(AliasExpression a, GuidExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, GuidExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableGuidExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableGuidExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region short
        public static FilterExpressionSet operator ==(AliasExpression a, Int16ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Int16ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, Int16ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, Int16ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, Int16ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, Int16ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableInt16ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableInt16ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableInt16ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableInt16ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableInt16ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableInt16ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region int
        public static FilterExpressionSet operator ==(AliasExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, Int32ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableInt32ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region long
        public static FilterExpressionSet operator ==(AliasExpression a, Int64ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, Int64ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, Int64ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, Int64ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, Int64ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, Int64ExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableInt64ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableInt64ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableInt64ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableInt64ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableInt64ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableInt64ExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region string?
        public static FilterExpressionSet operator ==(AliasExpression a, StringExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, StringExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, StringExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, StringExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, StringExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, StringExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region TimeSpan
        public static FilterExpressionSet operator ==(AliasExpression a, TimeSpanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, TimeSpanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, TimeSpanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, TimeSpanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, TimeSpanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, TimeSpanExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, NullableTimeSpanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, NullableTimeSpanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, NullableTimeSpanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, NullableTimeSpanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, NullableTimeSpanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, NullableTimeSpanExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region object?
        #endregion

        #endregion

        #region alias
        public static FilterExpressionSet operator ==(AliasExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(AliasExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(AliasExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(AliasExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(AliasExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==((string TableName, string FieldName) a, AliasExpression b) => new(new FilterExpression<bool?>(new AliasExpression(a.TableName, a.FieldName), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=((string TableName, string FieldName) a, AliasExpression b) => new(new FilterExpression<bool?>(new AliasExpression(a.TableName, a.FieldName), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <((string TableName, string FieldName) a, AliasExpression b) => new(new FilterExpression<bool?>(new AliasExpression(a.TableName, a.FieldName), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >((string TableName, string FieldName) a, AliasExpression b) => new(new FilterExpression<bool?>(new AliasExpression(a.TableName, a.FieldName), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=((string TableName, string FieldName) a, AliasExpression b) => new(new FilterExpression<bool?>(new AliasExpression(a.TableName, a.FieldName), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=((string TableName, string FieldName) a, AliasExpression b) => new(new FilterExpression<bool?>(new AliasExpression(a.TableName, a.FieldName), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }

    public partial class AliasExpression<T>
    {
        #region alias
        public static ObjectExpressionMediator operator +(AliasExpression<T> a, AliasExpression<T> b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(AliasExpression<T> a, AliasExpression<T> b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(AliasExpression<T> a, AliasExpression<T> b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(AliasExpression<T> a, AliasExpression<T> b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(AliasExpression<T> a, AliasExpression<T> b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
    }
}
