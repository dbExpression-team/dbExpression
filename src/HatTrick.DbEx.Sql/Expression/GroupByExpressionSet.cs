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
    public class GroupByExpressionSet : 
        IExpressionElement,
        IExpressionListProvider<AnyGroupByExpression>,
        IEquatable<GroupByExpressionSet>
    {
        #region interface
        public IEnumerable<AnyGroupByExpression> Expressions { get; private set; } = Array.Empty<AnyGroupByExpression>();
        #endregion

        #region constructors
        private GroupByExpressionSet()
        {

        }

        public GroupByExpressionSet(AnyGroupByExpression groupBy)
        {
            Expressions = Expressions.Concat(new AnyGroupByExpression[1] { (groupBy ?? throw new ArgumentNullException(nameof(groupBy))) is GroupByExpression ? groupBy : new GroupByExpression(groupBy) });
        }

        public GroupByExpressionSet(GroupByExpression aGroupBy, GroupByExpression bGroupBy)
        {
            Expressions = new List<AnyGroupByExpression>
            {
                aGroupBy ?? throw new ArgumentNullException(nameof(aGroupBy)),
                bGroupBy ?? throw new ArgumentNullException(nameof(bGroupBy))
            };
        }

        public GroupByExpressionSet(IEnumerable<AnyGroupByExpression> groupBys)
        {
            Expressions = (groupBys ?? throw new ArgumentNullException(nameof(groupBys))).Select(x => x is GroupByExpression ? x : new GroupByExpression(x));
        }
        #endregion

        #region to string
        public override string? ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region equals
        public bool Equals(GroupByExpressionSet? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!Expressions.SequenceEqual(obj.Expressions)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is GroupByExpressionSet exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                foreach (var exp in Expressions)
                    hash = (hash * multiplier) ^ (exp is not null ? exp.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpressionSet? a, GroupByExpression? b)
        {
            if (a is null && b is null)
                return new();

            if (a is null)
            {
                a = b!;
            }
            else
            {
                a.Expressions = a.Expressions.Concat(new AnyGroupByExpression[1] { b! });
            }
            return a;
        }

        public static GroupByExpressionSet operator &(GroupByExpressionSet? a, GroupByExpressionSet? b)
        {
            if (a is null)
                return b ?? new();

            if (b?.Expressions is null)
                return a;

            a.Expressions = a.Expressions.Concat(b.Expressions);

            return a;
        }
        #endregion
    }
    
}
