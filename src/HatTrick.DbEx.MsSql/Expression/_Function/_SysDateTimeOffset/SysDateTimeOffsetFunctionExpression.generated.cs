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
using HatTrick.DbEx.Sql.Expression;

#nullable enable

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysDateTimeOffsetFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeOffsetExpressionMediator(SysDateTimeOffsetFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region mediators
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region alias
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region DateTimeOffset
        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
