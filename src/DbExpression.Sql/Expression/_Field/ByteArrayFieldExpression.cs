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

﻿using System;

namespace DbExpression.Sql.Expression
{
    public abstract class ByteArrayFieldExpression : 
        FieldExpression<byte[]>,
        ByteArrayElement,
        IEquatable<ByteArrayFieldExpression>
    {
        #region constructors
        protected ByteArrayFieldExpression(int identifier, string name, Table entity) : base(identifier, name, typeof(byte[]), entity)
        {
        }
        #endregion

        #region equals
        public bool Equals(ByteArrayFieldExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is ByteArrayFieldExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator ByteArrayExpressionMediator(ByteArrayFieldExpression a) => new(a);
        #endregion

        #region filter operators
        #region byte[]
        public static FilterExpression<bool> operator ==(ByteArrayFieldExpression a, byte[] b) => new(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayFieldExpression a, byte[] b) => new(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(byte[] a, ByteArrayFieldExpression b) => new(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(byte[] a, ByteArrayFieldExpression b) => new(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediators
        public static FilterExpression<bool> operator ==(ByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(ByteArrayFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteArrayFieldExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
