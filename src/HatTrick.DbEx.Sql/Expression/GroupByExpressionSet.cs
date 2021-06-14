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
        IExpressionListProvider<AnyGroupByClause>
    {
        #region interface
        public IEnumerable<AnyGroupByClause> Expressions { get; private set; } = new List<AnyGroupByClause>();
        #endregion

        #region constructors
        private GroupByExpressionSet()
        {

        }

        public GroupByExpressionSet(AnyGroupByClause groupBy)
        {
            Expressions = Expressions.Concat(new AnyGroupByClause[1] { (groupBy ?? throw new ArgumentNullException(nameof(groupBy))) is GroupByExpression ? groupBy : new GroupByExpression(groupBy) });
        }

        public GroupByExpressionSet(GroupByExpression aGroupBy, GroupByExpression bGroupBy)
        {
            Expressions = new List<AnyGroupByClause>
            {
                aGroupBy ?? throw new ArgumentNullException(nameof(aGroupBy)),
                bGroupBy ?? throw new ArgumentNullException(nameof(bGroupBy))
            };
        }

        public GroupByExpressionSet(IEnumerable<AnyGroupByClause> groupBys)
        {
            Expressions = (groupBys ?? throw new ArgumentNullException(nameof(groupBys))).Select(x => x is GroupByExpression ? x : new GroupByExpression(x));
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpressionSet aSet, GroupByExpression b)
        {
            if (aSet is null)
            {
                aSet = b;
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new AnyGroupByClause[1] { b });
            }
            return aSet;
        }

        public static GroupByExpressionSet operator &(GroupByExpressionSet aSet, GroupByExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
