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

#nullable disable

namespace DbExpression.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableGuidExpressionMediator
    {
        #region arithmetic operators 
        #region data type 
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
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<Guid?>(b, field) : b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<Guid?>(b, field) : b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b.Expression is FieldExpression field ? new LiteralExpression<Guid?>(a, field) : a, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b.Expression is FieldExpression field ? new LiteralExpression<Guid?>(a, field) : a, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region Guid
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, Guid b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, Guid b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(Guid a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(Guid a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, Guid? b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, Guid? b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(Guid? a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(Guid? a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region fields
        #region Guid
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        #endregion

        #endregion
        
        #region mediator
        #region Guid
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableGuidExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<Guid?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<Guid?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableGuidExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<Guid?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual);

        #endregion
        #endregion
    }
}
