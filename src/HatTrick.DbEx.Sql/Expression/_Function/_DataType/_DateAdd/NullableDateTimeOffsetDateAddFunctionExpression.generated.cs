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
    public partial class NullableDateTimeOffsetDateAddFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDateTimeOffsetExpressionMediator(NullableDateTimeOffsetDateAddFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #endregion

        #region fields
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion        
        #endregion

        #region mediator
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region alias
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(DBNull a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DBNull a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region DateTimeOffset
        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeOffset a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeOffset? a, NullableDateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region fields
        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region mediators
        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableDateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #endregion
    }
}
