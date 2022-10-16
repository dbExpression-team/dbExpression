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
    public partial class TimeSpanIsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator TimeSpanExpressionMediator(TimeSpanIsNullFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        
        
        
        
        
        
        
        
        
        
        
        
        
        #endregion

        #region fields
        #region bool
        #endregion        
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
        #region Guid
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

        #region mediators
        #region bool
        #endregion
 
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
 
        #region Guid
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

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(TimeSpanIsNullFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(TimeSpanIsNullFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, TimeSpanIsNullFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, TimeSpanIsNullFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region TimeSpan
        public static FilterExpression<bool> operator ==(TimeSpanIsNullFunctionExpression a, TimeSpan b) => new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(TimeSpanIsNullFunctionExpression a, TimeSpan b) => new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator ==(TimeSpan a, TimeSpanIsNullFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(TimeSpan a, TimeSpanIsNullFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(TimeSpanIsNullFunctionExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(TimeSpanIsNullFunctionExpression a, TimeSpan? b) => new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(TimeSpan? a, TimeSpanIsNullFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(TimeSpan? a, TimeSpanIsNullFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region fields
        public static FilterExpression<bool> operator ==(TimeSpanIsNullFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(TimeSpanIsNullFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(TimeSpanIsNullFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(TimeSpanIsNullFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #region mediators
        #region TimeSpan
        public static FilterExpression<bool> operator ==(TimeSpanIsNullFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(TimeSpanIsNullFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(TimeSpanIsNullFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(TimeSpanIsNullFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(TimeSpanIsNullFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(TimeSpanIsNullFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(TimeSpanIsNullFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(TimeSpanIsNullFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TimeSpan>(b), FilterExpressionOperator.NotEqual);
        
        #endregion
        #endregion
    }
}
