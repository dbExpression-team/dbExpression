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

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class ObjectFieldExpression<T> :
        FieldExpression<T>,
        ObjectElement<T>,
        IEquatable<ObjectFieldExpression<T>>
        where T: class?
    {
        #region constructors
        protected ObjectFieldExpression(int identifier, string name, Table entity) : base(identifier, name, typeof(T), entity)
        {

        }
        #endregion

        #region as
        public new ObjectElement<T> As(string alias)
            => new ObjectSelectExpression<T>(this, alias);
        #endregion

        #region equals
        public bool Equals(ObjectFieldExpression<T>? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is ObjectFieldExpression<T> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator ObjectExpressionMediator(ObjectFieldExpression<T> a) => new(a);
        #endregion

        #region filter operators
        #region null
        public static FilterExpression operator ==(ObjectFieldExpression<T> a, NullElement b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectFieldExpression<T> a, NullElement b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b, a), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(NullElement a, ObjectFieldExpression<T> b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullElement a, ObjectFieldExpression<T> b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region object?
        public static FilterExpression operator ==(ObjectFieldExpression<T> a, T b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectFieldExpression<T> a, T b) => new FilterExpression<bool?>(a, new LiteralExpression<object?>(b, a), FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(T a, ObjectFieldExpression<T> b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(T a, ObjectFieldExpression<T> b) => new FilterExpression<bool?>(new LiteralExpression<object?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion

        #region fields
        public static FilterExpression operator ==(ObjectFieldExpression<T> a, ObjectFieldExpression<T> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectFieldExpression<T> a, ObjectFieldExpression<T> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediators
        public static FilterExpression operator ==(ObjectFieldExpression<T> a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectFieldExpression<T> a, ObjectExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(ObjectFieldExpression<T> a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectFieldExpression<T> a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(ObjectFieldExpression<T> a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ObjectFieldExpression<T> a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
