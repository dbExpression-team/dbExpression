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
    public partial class ObjectExpressionMediator
    {
        #region arithmetic operators
        #region data type
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion

        #region alias

        #endregion
        #endregion

        #region filter operators
        #region object?
        public static FilterExpression operator ==(ObjectExpressionMediator a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectExpressionMediator a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ObjectExpressionMediator a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ObjectExpressionMediator a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ObjectExpressionMediator a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ObjectExpressionMediator a, object? b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(object? a, ObjectExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(object? a, ObjectExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(object? a, ObjectExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(object? a, ObjectExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(object? a, ObjectExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(object? a, ObjectExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region fields

        #endregion

        #region mediators
        public static FilterExpression operator ==(ObjectExpressionMediator a, ObjectExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectExpressionMediator a, ObjectExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ObjectExpressionMediator a, ObjectExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ObjectExpressionMediator a, ObjectExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ObjectExpressionMediator a, ObjectExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ObjectExpressionMediator a, ObjectExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region alias
        public static FilterExpression operator ==(ObjectExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ObjectExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ObjectExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ObjectExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ObjectExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(ObjectExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ObjectExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ObjectExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ObjectExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ObjectExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
