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
    public partial class StringRightFunctionExpression
    {
        #region implicit operators
        public static implicit operator StringExpressionMediator(StringRightFunctionExpression a) => new(a);
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

        #region mediators
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
        #region data types
        #region string?
        public static FilterExpression operator ==(StringRightFunctionExpression a, string? b) => new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(StringRightFunctionExpression a, string? b) => new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(StringRightFunctionExpression a, string? b) => new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(StringRightFunctionExpression a, string? b) => new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(StringRightFunctionExpression a, string? b) => new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(StringRightFunctionExpression a, string? b) => new FilterExpression<bool>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(string? a, StringRightFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(string? a, StringRightFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(string? a, StringRightFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(string? a, StringRightFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(string? a, StringRightFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(string? a, StringRightFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region fields
        public static FilterExpression operator ==(StringRightFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(StringRightFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(StringRightFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(StringRightFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(StringRightFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(StringRightFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        

        #endregion

        #region mediators
        public static FilterExpression operator ==(StringRightFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(StringRightFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(StringRightFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(StringRightFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(StringRightFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(StringRightFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region alias
        public static FilterExpression operator ==(StringRightFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(StringRightFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(StringRightFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(StringRightFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(StringRightFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(StringRightFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(StringRightFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(StringRightFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(StringRightFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(StringRightFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(StringRightFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(StringRightFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
