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
    public partial class NullableObjectCoalesceFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableObjectExpressionMediator(NullableObjectCoalesceFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
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

        #region fields
        #endregion

        #region mediator
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression operator ==(NullableObjectCoalesceFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableObjectCoalesceFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(NullElement a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullElement a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region object?
        public static FilterExpression operator ==(NullableObjectCoalesceFunctionExpression a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableObjectCoalesceFunctionExpression a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableObjectCoalesceFunctionExpression a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableObjectCoalesceFunctionExpression a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableObjectCoalesceFunctionExpression a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableObjectCoalesceFunctionExpression a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(object? a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(object? a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(object? a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(object? a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(object? a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(object? a, NullableObjectCoalesceFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region fields
        #endregion

        #region mediators
        public static FilterExpression operator ==(NullableObjectCoalesceFunctionExpression a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableObjectCoalesceFunctionExpression a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableObjectCoalesceFunctionExpression a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableObjectCoalesceFunctionExpression a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableObjectCoalesceFunctionExpression a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableObjectCoalesceFunctionExpression a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region alias
        public static FilterExpression operator ==(NullableObjectCoalesceFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableObjectCoalesceFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableObjectCoalesceFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableObjectCoalesceFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableObjectCoalesceFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableObjectCoalesceFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(NullableObjectCoalesceFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableObjectCoalesceFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableObjectCoalesceFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableObjectCoalesceFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableObjectCoalesceFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableObjectCoalesceFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #endregion
    }
}
