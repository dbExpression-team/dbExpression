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

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FunctionExpression :
        AnyElement,
        AnyOrderByExpression,
        IFunctionExpression,
        IExpressionTypeProvider,
        IEquatable<FunctionExpression>
    {
        #region internals
        protected Type DeclaredType { get; private set; } = typeof(object);
        #endregion

        #region interface
        Type IExpressionTypeProvider.DeclaredType => DeclaredType;
        #endregion

        #region constructors
        private FunctionExpression()
        {
        }

        protected FunctionExpression(Type declaredType)
        {
            DeclaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
        }
        #endregion

        #region order
        public OrderByExpression Asc => new(this, OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new(this, OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(FunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (DeclaredType != obj?.DeclaredType) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is FunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ DeclaredType.GetHashCode();
                return hash;
            }
        }
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(FunctionExpression a) => new(a, OrderExpressionDirection.ASC);
        #endregion
    }
}
