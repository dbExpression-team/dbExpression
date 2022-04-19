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
    public partial class NullableTimeSpanFieldExpression
    {
        #region in value set
        public override FilterExpression In(params TimeSpan?[] value) => new FilterExpression<bool?>(this, new InExpression<TimeSpan?>(this, value), FilterExpressionOperator.None);
        public override FilterExpression In(IEnumerable<TimeSpan?> value) => new FilterExpression<bool?>(this, new InExpression<TimeSpan?>(this, value), FilterExpressionOperator.None);
        #endregion

        #region implicit operators
        public static implicit operator NullableTimeSpanExpressionMediator(NullableTimeSpanFieldExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte



        #endregion        

        #region decimal



        #endregion        

        #region DateTime



        #endregion        

        #region DateTimeOffset



        #endregion        

        #region double



        #endregion        

        #region float



        #endregion        

        #region short



        #endregion        

        #region int



        #endregion        

        #region long



        #endregion        

        #region string?


        #endregion        

        #region TimeSpan



        #endregion        

        #endregion

        #region fields











        #endregion

        #region mediators











        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(DBNull a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DBNull a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region TimeSpan
        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b, a), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b, a), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b, a), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b, a), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b, a), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a, b), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region fields
        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediators
        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(NullableTimeSpanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableTimeSpanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableTimeSpanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableTimeSpanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableTimeSpanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableTimeSpanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
