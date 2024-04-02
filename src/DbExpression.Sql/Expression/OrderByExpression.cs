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
    public class OrderByExpression :
        AnyOrderByExpression,
        IEquatable<OrderByExpression>
    {
        #region interface
        public IExpressionElement Expression { get; private set; }
        public OrderExpressionDirection Direction { get; private set; }
        #endregion

        #region constructors
        public OrderByExpression(IExpressionElement orderBy, OrderExpressionDirection direction)
        {
            Expression = orderBy ?? throw new ArgumentNullException(nameof(orderBy));
            Direction = direction;
        }
        #endregion

        #region to string
        public override string? ToString() => $"{Expression} {Direction}";
        #endregion

        #region equals
        public bool Equals(OrderByExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!Expression.Equals(obj.Expression)) return false;
            if (Direction != obj.Direction) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is OrderByExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is not null ? Expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ Direction.GetHashCode();
                return hash;
            }
        }
        #endregion

        #region conditional & operator
        public static OrderByExpressionSet operator &(OrderByExpression a, OrderByExpression b) => new(a, b);
        #endregion

        #region implicit operator
        public static implicit operator OrderByExpressionSet(OrderByExpression a) => new(a);

        public static implicit operator OrderByExpression((string TableName, string FieldName) a) => new(new AliasExpression<object?>(a), OrderExpressionDirection.ASC);
        #endregion
    }

}
