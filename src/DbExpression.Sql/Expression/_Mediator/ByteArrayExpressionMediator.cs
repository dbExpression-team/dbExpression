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
    public partial class ByteArrayExpressionMediator :
        ExpressionMediator<byte[]>,
        ByteArrayElement,
        IEquatable<ByteArrayExpressionMediator>
    {
        #region constructors
        private ByteArrayExpressionMediator()
        {
        }

        public ByteArrayExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }
        #endregion

        #region equals
        public bool Equals(ByteArrayExpressionMediator? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is ByteArrayExpressionMediator exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region filter operators
        #region byte[]
        public static FilterExpression operator ==(ByteArrayExpressionMediator a, byte[] b) => new FilterExpression<bool>(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteArrayExpressionMediator a, byte[] b) => new FilterExpression<bool>(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(byte[] a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(byte[] a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region fields
        public static FilterExpression operator ==(ByteArrayExpressionMediator a, ByteArrayFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteArrayExpressionMediator a, ByteArrayFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediators
        public static FilterExpression operator ==(ByteArrayExpressionMediator a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteArrayExpressionMediator a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
