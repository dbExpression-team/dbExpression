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

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableTimeSpanExpressionMediator(NullableTimeSpanMinimumFunctionExpression a) => new NullableTimeSpanExpressionMediator(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte



        
        #endregion
        
        #region decimal



        
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
        
        #endregion

        #region fields
        #region byte

        #endregion        
        #region decimal

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
        #endregion

        #region mediator
        #region byte

        #endregion
        
        #region decimal

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
        
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region TimeSpan
        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMinimumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableTimeSpanMinimumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMinimumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableTimeSpanMinimumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpan a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpan a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpan a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMinimumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableTimeSpanMinimumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMinimumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableTimeSpanMinimumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan? a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan? a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan? a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpan? a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpan? a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpan? a, NullableTimeSpanMinimumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMinimumFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableTimeSpanMinimumFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMinimumFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableTimeSpanMinimumFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMinimumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableTimeSpanMinimumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMinimumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableTimeSpanMinimumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableTimeSpanMinimumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableTimeSpanMinimumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMinimumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMinimumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableTimeSpanMinimumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMinimumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableTimeSpanMinimumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
