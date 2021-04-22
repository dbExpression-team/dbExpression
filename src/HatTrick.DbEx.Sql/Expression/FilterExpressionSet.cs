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
    public class FilterExpressionSet :
        AnyWhereClause,
        AnyJoinOnClause,
        AnyHavingClause
    {
        #region interface
        public ConditionalExpressionOperator ConditionalOperator { get; private set; }
        public bool Negate { get; private set; }
        public IFilterExpressionElement LeftArg { get; private set; }
        public IFilterExpressionElement RightArg { get; private set; }
        public bool IsSingleArg => RightArg is null;
        public bool IsEmpty => LeftArg is null && RightArg is null;
        #endregion

        #region constructors
        private FilterExpressionSet()
        { 
        
        }        
        
        public FilterExpressionSet(FilterExpression singleArg)
        {
            LeftArg = singleArg ?? throw new ArgumentNullException(nameof(singleArg));
        }

        public FilterExpressionSet(FilterExpression leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ConditionalOperator = conditionalOperator;
        }

        public FilterExpressionSet(FilterExpressionSet leftArg, FilterExpressionSet rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ConditionalOperator = conditionalOperator;
        }

        private FilterExpressionSet(FilterExpressionSet leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ConditionalOperator = conditionalOperator;
        }
        #endregion

        #region to string
        public override string ToString() => (Negate) ? $"NOT ({LeftArg}{(RightArg is object ? $"{ConditionalOperator} {RightArg}" : string.Empty)})" : $"{LeftArg}{(RightArg is object ? $"{ConditionalOperator} {RightArg}" : string.Empty)}";
        #endregion

        #region implicit operators
        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpression b)
        {
            if (a is null && b is object) { return new FilterExpressionSet(b); }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                a.RightArg = b;
                a.ConditionalOperator = ConditionalExpressionOperator.And;
                return a;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpressionSet b)
        {
            if (a is null && b is object) { return b; }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                if (b.IsSingleArg && b.LeftArg is FilterExpression inner_bFilter)
                {
                    inner_bFilter.Negate = b.Negate;
                    a.RightArg = inner_bFilter;
                }
                else
                {
                    a.RightArg = b;
                }
                a.ConditionalOperator = ConditionalExpressionOperator.And;
                return a;
            }

            if (b.IsSingleArg && b.LeftArg is FilterExpression bFilter)
            {
                bFilter.Negate = b.Negate;
                b.Negate = false;
                if (a.IsSingleArg && a.LeftArg is FilterExpression inner_aFilter)
                {
                    inner_aFilter.Negate = a.Negate;
                    b.RightArg = b.LeftArg;
                    b.LeftArg = inner_aFilter;
                }
                else
                {
                    b.RightArg = b.LeftArg;
                    b.LeftArg = a;
                }
                b.ConditionalOperator = ConditionalExpressionOperator.And;
                return b;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpression b)
        {
            if (a is null && b is object) { return new FilterExpressionSet(b); }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                a.RightArg = b;
                a.ConditionalOperator = ConditionalExpressionOperator.Or;
                return a;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpressionSet b)
        {
            if (a is null && b is object) { return b; }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                if (b.IsSingleArg && b.LeftArg is FilterExpression inner_bFilter)
                {
                    inner_bFilter.Negate = b.Negate;
                    a.RightArg = inner_bFilter;
                }
                else
                {
                    a.RightArg = b;
                }
                a.ConditionalOperator = ConditionalExpressionOperator.Or;
                return a;
            }

            if (b.IsSingleArg && b.LeftArg is FilterExpression bFilter)
            {
                bFilter.Negate = b.Negate;
                b.Negate = false;
                if (a.IsSingleArg && a.LeftArg is FilterExpression inner_aFilter)
                {
                    inner_aFilter.Negate = a.Negate;
                    b.RightArg = b.LeftArg;
                    b.LeftArg = inner_aFilter;
                }
                else
                {
                    b.RightArg = b.LeftArg;
                    b.LeftArg = a;
                }
                b.ConditionalOperator = ConditionalExpressionOperator.Or;
                return b;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }

        public static implicit operator JoinOnExpressionSet(FilterExpressionSet filter)
            => filter.ConvertToJoinOnExpressionSet();

        public static implicit operator HavingExpression(FilterExpressionSet a) 
            => new HavingExpression(a);

        public static FilterExpressionSet operator !(FilterExpressionSet filter)
        {
            if (filter is object) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
}
