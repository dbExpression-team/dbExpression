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
using DbExpression.Sql;

#nullable disable

namespace DbExpression.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class BooleanCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator BooleanExpressionMediator(BooleanCastFunctionExpression a) => new(a);
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
        #region string
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
 
        #region string
        #endregion
 
        #region TimeSpan
        #endregion
 
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(BooleanCastFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(BooleanCastFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, BooleanCastFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, BooleanCastFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region bool
        public static FilterExpression<bool> operator ==(BooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(BooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator ==(bool a, BooleanCastFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(bool a, BooleanCastFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(BooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(BooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(bool? a, BooleanCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(bool? a, BooleanCastFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region fields
        public static FilterExpression<bool> operator ==(BooleanCastFunctionExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(BooleanCastFunctionExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(BooleanCastFunctionExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(BooleanCastFunctionExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #region mediators
        #region bool
        public static FilterExpression<bool> operator ==(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(BooleanCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(BooleanCastFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(BooleanCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<bool>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, BooleanCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<bool>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(BooleanCastFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<bool>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, BooleanCastFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<bool>(a), b, FilterExpressionOperator.NotEqual);

        #endregion
        #endregion
    }
}
