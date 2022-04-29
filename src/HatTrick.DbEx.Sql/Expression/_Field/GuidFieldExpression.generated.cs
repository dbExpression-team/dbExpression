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
    public partial class GuidFieldExpression
    {
        #region in value set
        public override FilterExpression In(params Guid[] value) => new FilterExpression<bool>(this, new InExpression<Guid>(this, value), FilterExpressionOperator.None);
        public override FilterExpression In(IEnumerable<Guid> value) => new FilterExpression<bool>(this, new InExpression<Guid>(this, value), FilterExpressionOperator.None);
        #endregion

        #region implicit operators
        public static implicit operator GuidExpressionMediator(GuidFieldExpression a) => new(a);
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
        #region DBNull
        public static FilterExpression operator ==(GuidFieldExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, DBNull b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(DBNull a, GuidFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DBNull a, GuidFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region Guid
        public static FilterExpression operator ==(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(a, new LiteralExpression<Guid>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(a, new LiteralExpression<Guid>(b, a), FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new LiteralExpression<Guid>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new LiteralExpression<Guid>(a, b), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b, a), FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<Guid?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion

        #region fields
        public static FilterExpression operator ==(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        
        #region mediators
        public static FilterExpression operator ==(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(GuidFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(GuidFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<Guid>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(GuidFieldExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<Guid>(b), FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
