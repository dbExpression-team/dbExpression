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
    public class RawExpression :
        IExpressionElement,
        ObjectElement<string>,
        IEquatable<RawExpression>
    {
        #region interface
        public string Expression { get; private set; }

        public OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);

        public OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region constructors
        public RawExpression(string expression)
        {
            Expression = expression;
        }
        #endregion

        #region as
        public AnyElement<string> As(string alias)
            => new SelectExpression<string>(this).As(alias);
        #endregion

        #region tostring
        public override string ToString() => Expression ?? "null";
        #endregion

        #region equals
        public bool Equals(RawExpression obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!StringComparer.OrdinalIgnoreCase.Equals(Expression, obj.Expression)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is RawExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is object ? Expression.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
