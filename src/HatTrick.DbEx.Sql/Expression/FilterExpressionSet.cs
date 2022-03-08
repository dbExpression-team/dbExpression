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
        AnyHavingClause,
        IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>,
        IEquatable<FilterExpressionSet>
    {
        #region internals
        private readonly FilterExpressionSetElements elements;
        #endregion

        #region interface
        FilterExpressionSetElements IExpressionProvider<FilterExpressionSetElements>.Expression => elements;
        #endregion

        #region constructors
        public FilterExpressionSet(IFilterExpressionElement singleArg)
        {
            elements = new FilterExpressionSetElements(singleArg, null, default, false);
        }

        public FilterExpressionSet(FilterExpression singleArg)
        {
            elements = new FilterExpressionSetElements(singleArg, null, default, false);
        }

        public FilterExpressionSet(FilterExpression leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            elements = new FilterExpressionSetElements(leftArg, rightArg, conditionalOperator, false);
        }

        public FilterExpressionSet(FilterExpressionSet leftArg, FilterExpressionSet? rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            elements = new FilterExpressionSetElements(leftArg, rightArg, conditionalOperator, false);
        }
        #endregion

        #region to string
        public override string? ToString() => (elements.Negate) ? $"NOT ({elements.LeftArg}{(elements.RightArg is not null ? $"{elements.ConditionalOperator} {elements.RightArg}" : string.Empty)})" : $"{elements.LeftArg}{(elements.RightArg is not null ? $"{elements.ConditionalOperator} {elements.RightArg}" : string.Empty)}";
        #endregion

        #region equals
        public bool Equals(FilterExpressionSet? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!elements.Equals(obj.elements)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is FilterExpressionSet exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (elements is not null ? elements.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region implicit operators
        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpression? b)
            => Operator(a, b, ConditionalExpressionOperator.And);

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpression? b)
            => Operator(a, b, ConditionalExpressionOperator.Or);

        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpressionSet? b)
            => Operator(a, b, ConditionalExpressionOperator.And);

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpressionSet? b)
            => Operator(a, b, ConditionalExpressionOperator.Or);

        private static FilterExpressionSet Operator(FilterExpressionSet? a, FilterExpression? b, ConditionalExpressionOperator expressionOperator)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            if (b is null) return a!;

            var nonNull = a ?? b;
            var mayBeNull = b ?? a;

            if (nonNull.elements.IsSingleArg && nonNull.elements.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = nonNull.elements.Negate;
                nonNull.elements.Negate = false;
                nonNull.elements.RightArg = mayBeNull;
                nonNull.elements.ConditionalOperator = expressionOperator;
                return nonNull;
            }

            return new FilterExpressionSet(a ?? b!, b ?? a, ConditionalExpressionOperator.And);
        }

        private static FilterExpressionSet Operator(FilterExpressionSet? a, FilterExpressionSet? b, ConditionalExpressionOperator expressionOperator)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            if (b is null) return a!;

            var nonNull = a ?? b;
            var mayBeNull = (b ?? a)!;

            if (nonNull.elements.IsSingleArg && nonNull.elements.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = nonNull.elements.Negate;
                nonNull.elements.Negate = false;
                if (mayBeNull.elements.IsSingleArg && mayBeNull.elements.LeftArg is FilterExpression inner_bFilter)
                {
                    inner_bFilter.Negate = mayBeNull.elements.Negate;
                    nonNull.elements.RightArg = inner_bFilter;
                }
                else
                {
                    nonNull.elements.RightArg = mayBeNull;
                }
                nonNull.elements.ConditionalOperator = expressionOperator;
                return nonNull;
            }

            return new FilterExpressionSet(a ?? b!, b ?? a, expressionOperator);
        }

        public static implicit operator JoinOnExpressionSet(FilterExpressionSet filter)
            => filter.ConvertToJoinOnExpressionSet();

        public static implicit operator HavingExpression(FilterExpressionSet a) 
            => new(a);

        public static FilterExpressionSet operator !(FilterExpressionSet filter)
        {
            filter.elements.Negate = !filter.elements.Negate;
            return filter;
        }
        #endregion

        #region classes
        public class FilterExpressionSetElements : IExpressionElement, IEquatable<FilterExpressionSetElements>
        {
            #region interface
            public ConditionalExpressionOperator ConditionalOperator { get; set; }
            public bool Negate { get; set; }
            public IFilterExpressionElement LeftArg { get; set; }
            public IFilterExpressionElement? RightArg { get; set; }
            public bool IsSingleArg => RightArg is null;
            public bool IsEmpty => LeftArg is null && RightArg is null;
            #endregion

            #region constructors
            public FilterExpressionSetElements(IFilterExpressionElement leftArg, IFilterExpressionElement? rightArg, ConditionalExpressionOperator conditionalOperator, bool negate)
            {
                LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
                RightArg = rightArg;
                ConditionalOperator = conditionalOperator;
                Negate = negate;
            }
            #endregion

            #region equals
            public bool Equals(FilterExpressionSetElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (LeftArg is null && obj.LeftArg is not null) return false;
                if (LeftArg is not null && obj.LeftArg is null) return false;
                if (LeftArg is not null && !LeftArg.Equals(obj.LeftArg)) return false;

                if (RightArg is null && obj.RightArg is not null) return false;
                if (RightArg is not null && obj.RightArg is null) return false;
                if (RightArg is not null && !RightArg.Equals(obj.RightArg)) return false;

                if (Negate != obj.Negate) return false;

                if (ConditionalOperator != obj.ConditionalOperator) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is FilterExpressionSetElements exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int @base = (int)2166136261;
                    const int multiplier = 16777619;

                    int hash = @base;
                    hash = (hash * multiplier) ^ (LeftArg is not null ? LeftArg.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (RightArg is not null ? RightArg.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ Negate.GetHashCode();
                    hash = (hash * multiplier) ^ ConditionalOperator.GetHashCode();
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
