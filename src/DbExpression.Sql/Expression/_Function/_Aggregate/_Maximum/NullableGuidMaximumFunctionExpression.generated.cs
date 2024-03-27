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
    public partial class NullableGuidMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableGuidExpressionMediator(NullableGuidMaximumFunctionExpression a) => new(a);
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
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region Guid
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, Guid b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, Guid b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(Guid a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(Guid a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, Guid? b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, Guid? b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(Guid? a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(Guid? a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region fields
        #region Guid
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, GuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, GuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region mediators
        #region Guid
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableGuidMaximumFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<Guid>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<Guid>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableGuidMaximumFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<Guid>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableGuidMaximumFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<Guid>(a), b, FilterExpressionOperator.NotEqual);

        #endregion

        #endregion
    }
}
