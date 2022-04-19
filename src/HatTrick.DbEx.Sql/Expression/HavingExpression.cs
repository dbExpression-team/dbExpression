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
    public class HavingExpression :
        AnyHavingClause,
        IExpressionProvider<FilterExpressionSet>,
        IFilterExpressionElement,
        IEquatable<HavingExpression>
    {
        #region internals
        private FilterExpressionSet? expression;
        #endregion

        #region interface
        FilterExpressionSet IExpressionProvider<FilterExpressionSet>.Expression => expression!;
        #endregion

        #region constructors
        public HavingExpression(FilterExpressionSet havingCondition)
        {
            expression = havingCondition ?? throw new ArgumentNullException(nameof(havingCondition));
        }

        public HavingExpression(FilterExpression havingCondition)
        {
            expression = new(havingCondition ?? throw new ArgumentNullException(nameof(havingCondition)));
        }
        #endregion

        #region to string
        public override string? ToString() => expression?.ToString();
        #endregion

        #region conditional & operator
        public static HavingExpression? operator &(HavingExpression? a, HavingExpression? b)
        {
            if (a?.expression is null)
                return b;

            if (b?.expression is null)
                return a;

            a.expression &= new FilterExpressionSet(a.expression, b.expression, ConditionalExpressionOperator.And);

            return a;
        }
        #endregion

        #region equals
        public bool Equals(HavingExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (expression is null && obj.expression is not null) return false;
            if (expression is not null && obj.expression is null) return false;
            if (expression is not null && !expression.Equals(obj.expression)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is HavingExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (expression is not null ? expression.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }

}
