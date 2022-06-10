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
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class OrderByExpressionSet :
        AnyOrderByExpression,
        IExpressionListProvider<AnyOrderByExpression>,
        IEquatable<OrderByExpressionSet>
    {
        #region interface
        public IEnumerable<AnyOrderByExpression> Expressions { get; private set; }  = new List<AnyOrderByExpression>();
        #endregion

        #region constructors
        private OrderByExpressionSet()
        {

        }

        public OrderByExpressionSet(AnyOrderByExpression orderBy)
        {
            Expressions = Expressions.Concat(new AnyOrderByExpression[1] { (orderBy ?? throw new ArgumentNullException(nameof(orderBy))) is OrderByExpression ? orderBy : new OrderByExpression(orderBy, OrderExpressionDirection.ASC) });
        }

        public OrderByExpressionSet(OrderByExpression aOrderBy, OrderByExpression bOrderBy)
        {
            Expressions = new List<AnyOrderByExpression>
            {
                aOrderBy ?? throw new ArgumentNullException(nameof(aOrderBy)),
                bOrderBy ?? throw new ArgumentNullException(nameof(bOrderBy))
            };
        }

        public OrderByExpressionSet(IEnumerable<AnyOrderByExpression> orderBys)
        {
            Expressions = (orderBys ?? throw new ArgumentNullException(nameof(orderBys))).Select(x => x is OrderByExpression ? x : new OrderByExpression(x, OrderExpressionDirection.ASC));
        }
        #endregion

        #region to string
        public override string? ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region equals
        public bool Equals(OrderByExpressionSet? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!Expressions.SequenceEqual(obj.Expressions)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is OrderByExpressionSet exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                foreach (var expression in Expressions)
                    hash = (hash * multiplier) ^ (expression is not null ? expression.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region condition & operators
        public static OrderByExpressionSet operator &(OrderByExpressionSet? a, OrderByExpression? b)
        {
            if (a is null && b is null)
                return new();

            if (a is null)
            {
                a = new(b!);
            }
            else if (b is not null)
            {
                a.Expressions = a.Expressions.Concat(new AnyOrderByExpression[1] { b });
            }
            return a;

        }

        public static OrderByExpressionSet operator &(OrderByExpressionSet? a, OrderByExpressionSet? b)
        {
            if (a is null && b is null)
                return new();

            if (a is null)
                return b!;

            if (b?.Expressions is null)
                return a;

            a.Expressions = a.Expressions.Concat(b.Expressions);
            return a;
        }
        #endregion
    }
    
}
