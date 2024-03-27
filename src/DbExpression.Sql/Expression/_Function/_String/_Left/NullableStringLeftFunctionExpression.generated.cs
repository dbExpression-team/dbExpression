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
    public partial class NullableStringLeftFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableStringExpressionMediator(NullableStringLeftFunctionExpression a) => new(a);
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
        #region null
        public static FilterExpression<bool?> operator ==(NullableStringLeftFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringLeftFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region string
        public static FilterExpression<bool?> operator ==(NullableStringLeftFunctionExpression a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringLeftFunctionExpression a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableStringLeftFunctionExpression a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableStringLeftFunctionExpression a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableStringLeftFunctionExpression a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableStringLeftFunctionExpression a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(string a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(string a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(string a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(string a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(string a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(string a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        #region string
        public static FilterExpression<bool?> operator ==(NullableStringLeftFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringLeftFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableStringLeftFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableStringLeftFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableStringLeftFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableStringLeftFunctionExpression a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region mediators
        #region string
        public static FilterExpression<bool?> operator ==(NullableStringLeftFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringLeftFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableStringLeftFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableStringLeftFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableStringLeftFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableStringLeftFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableStringLeftFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringLeftFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableStringLeftFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableStringLeftFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableStringLeftFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableStringLeftFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableStringLeftFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableStringLeftFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableStringLeftFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableStringLeftFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableStringLeftFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableStringLeftFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, NullableStringLeftFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #endregion
    }
}
