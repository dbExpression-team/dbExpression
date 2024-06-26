﻿#region license
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

namespace DbExpression.Sql.Expression
{
    public sealed class NullExpression : NullElement
    {
        #region interface
        Type IExpressionTypeProvider.DeclaredType => typeof(object);
        #endregion

        #region methods
        #region as
        public AliasedElement As(string alias)
            => new SelectExpression(this, alias);
        #endregion

        #region to string
        public override string? ToString() => "NULL";
        #endregion

        #region order
        public OrderByExpression Asc() => new(this, OrderExpressionDirection.ASC);
        public OrderByExpression Desc() => new(this, OrderExpressionDirection.DESC);
        #endregion

        #region operators
        public static bool operator ==(NullExpression? obj1, NullExpression? obj2)
        {
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1 is NullExpression;
        }

        public static bool operator !=(NullExpression? obj1, NullExpression? obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(NullExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;

            return obj is NullExpression;
        }

        public override bool Equals(object? obj)
            => obj is NullExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                return (int)2166136261;
            }
        }
        #endregion
        #endregion
    }
}
