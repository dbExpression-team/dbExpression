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
using System.Collections.Generic;

#nullable enable

namespace HatTrick.DbEx.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableBooleanFieldExpression
    {
        #region in value set
        public override FilterExpression In(params bool?[] value) => new FilterExpression<bool?>(this, new InExpression<bool?>(this, value), FilterExpressionOperator.None);
        
        public override FilterExpression In(IEnumerable<bool?> value) => new FilterExpression<bool?>(this, new InExpression<bool?>(this, value), FilterExpressionOperator.None);
        #endregion

        #region implicit operators
        public static implicit operator NullableBooleanExpressionMediator(NullableBooleanFieldExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, NullElement b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, NullElement b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(a, new LiteralExpression<bool>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(a, new LiteralExpression<bool>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a, b), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b, a), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b, a), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a, b), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<bool?>(a, b), b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region fields
        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region mediators
        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<bool?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<bool?>(b), FilterExpressionOperator.NotEqual);
        
        #endregion
        #endregion
    }
}
