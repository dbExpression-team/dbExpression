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
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableStringCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableStringExpressionMediator(NullableStringCastFunctionExpression a) => new(a);
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
        public static NullableStringExpressionMediator operator +(NullableStringCastFunctionExpression a, StringFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));

        #endregion        
        #region TimeSpan

        #endregion        
        #endregion

        #region mediator
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
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region alias
        public static NullableStringExpressionMediator operator +(NullableStringCastFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableStringExpressionMediator operator +(NullableStringCastFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<string?>(b), ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression operator ==(NullableStringCastFunctionExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableStringCastFunctionExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(DBNull a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DBNull a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region string?
        public static FilterExpression operator ==(NullableStringCastFunctionExpression a, string? b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableStringCastFunctionExpression a, string? b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableStringCastFunctionExpression a, string? b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableStringCastFunctionExpression a, string? b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableStringCastFunctionExpression a, string? b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableStringCastFunctionExpression a, string? b) => new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(string? a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(string? a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(string? a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(string? a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(string? a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(string? a, NullableStringCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region fields
        public static FilterExpression operator ==(NullableStringCastFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableStringCastFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableStringCastFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableStringCastFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableStringCastFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableStringCastFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        

        #endregion

        #region mediators
        public static FilterExpression operator ==(NullableStringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableStringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableStringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableStringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableStringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableStringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region alias
        public static FilterExpression operator ==(NullableStringCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableStringCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableStringCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableStringCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableStringCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableStringCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(NullableStringCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableStringCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableStringCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableStringCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableStringCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableStringCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #endregion
    }
}
