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

﻿using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableByteArrayFieldExpression :
        FieldExpression<byte[]>,
        NullableByteArrayElement,
        AnyByteArrayElement,
        IEquatable<NullableByteArrayFieldExpression>
    {
        #region constructors
        protected NullableByteArrayFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(byte[]), entity)
        {

        }
        #endregion

        #region as
        public abstract NullableByteArrayElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableByteArrayFieldExpression obj)
            => obj is NullableByteArrayFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteArrayFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region in value set
        public override FilterExpressionSet In(params byte[][] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<byte[]>(this, value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<byte[]> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<byte[]>(this, value), FilterExpressionOperator.None)) : null;
        #endregion

        #region implicit operators
        public static implicit operator NullableByteArrayExpressionMediator(NullableByteArrayFieldExpression a) => new NullableByteArrayExpressionMediator(a);
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableByteArrayFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<byte[]>(b, a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableByteArrayFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<byte[]>(b, a), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableByteArrayFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<byte[]>(a, b), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableByteArrayFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<byte[]>(a, b), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region byte[]
        public static FilterExpression<bool?> operator ==(NullableByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool?>(a, new LiteralExpression<byte[]>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool?>(a, new LiteralExpression<byte[]>(b, a), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(byte[] a, NullableByteArrayFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte[]>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte[] a, NullableByteArrayFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte[]>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
