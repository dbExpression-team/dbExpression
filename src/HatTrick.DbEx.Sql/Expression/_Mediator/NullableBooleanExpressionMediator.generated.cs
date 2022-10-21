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
    public partial class NullableBooleanExpressionMediator
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
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<bool?>(b, field) : b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<bool?>(b, field) : b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b.Expression is FieldExpression field ? new LiteralExpression<bool?>(a, field) : a, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b.Expression is FieldExpression field ? new LiteralExpression<bool?>(a, field) : a, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, bool b) => new FilterExpression<bool?>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, bool b) => new FilterExpression<bool?>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(bool a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(bool a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, bool? b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, bool? b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(bool? a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(bool? a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region fields
        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        #endregion

        #endregion
        
        #region mediator
        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableBooleanExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<bool?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<bool?>(b), FilterExpressionOperator.NotEqual);
        
        #endregion
        #endregion
    }
}
