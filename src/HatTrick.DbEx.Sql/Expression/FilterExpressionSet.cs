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

using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private static readonly Lazy<Dictionary<ConditionalExpressionOperator, string>> conditionalOperatorMap = new(() => typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators().ToDictionary(k => k.Key, v => v.Value!));
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

        public FilterExpressionSet(FilterExpression leftArg, FilterExpression? rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            elements = new FilterExpressionSetElements(leftArg, rightArg, conditionalOperator, false);
        }

        public FilterExpressionSet(FilterExpressionSet leftArg, FilterExpressionSet? rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            elements = new FilterExpressionSetElements(leftArg, rightArg, conditionalOperator, false);
        }

        public FilterExpressionSet(FilterExpression leftArg, FilterExpressionSet? rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            elements = new FilterExpressionSetElements(leftArg, rightArg, conditionalOperator, false);
        }

        private FilterExpressionSet(FilterExpressionSet leftArg, FilterExpression? rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            elements = new FilterExpressionSetElements(leftArg, rightArg, conditionalOperator, false);
        }
        #endregion

        #region to string
        public override string? ToString()
        {
            var sb = new StringBuilder();
            if (elements.Negate)
                sb.Append("NOT (");
            for (var i = 0; i < elements.Args.Count(); i++)
            {
                sb.Append(elements.Args.ElementAt(i).ToString());
                if (i < elements.Args.Count - 1)
                {
                    sb.Append(' ');
                    sb.Append(conditionalOperatorMap.Value[elements.ConditionalOperator]);
                    sb.Append(' ');
                }
            }
            if (elements.Negate)
                sb.Append(')');
            return sb.ToString();
        }
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

            if (a!.elements.ConditionalOperator == expressionOperator)
            {
                a.elements.Args.Add(b);
                return a;
            }
            return new FilterExpressionSet(a, b, expressionOperator);
        }

        private static FilterExpressionSet Operator(FilterExpressionSet? a, FilterExpressionSet? b, ConditionalExpressionOperator expressionOperator)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            if (b is null) return a!;

            if (a is not null)
            {
                if (a.elements.Args.Count() == 1) //single filter wrapped in a set
                {
                    a.elements.Args.Add(b);
                    a.elements.ConditionalOperator = expressionOperator;
                    return a;
                }
                if (a.elements.ConditionalOperator == expressionOperator)
                {
                    a.elements.Args.Add(b);
                    return a;
                }
                return new FilterExpressionSet(a, b, expressionOperator);
            }
            return b;
        }

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
            public IList<IFilterExpressionElement> Args { get; } = new List<IFilterExpressionElement>();
            #endregion

            #region constructors
            public FilterExpressionSetElements(IFilterExpressionElement leftArg, IFilterExpressionElement? rightArg, ConditionalExpressionOperator conditionalOperator, bool negate)
            {
                ConditionalOperator = conditionalOperator;
                Negate = negate;

                Args.Add(leftArg);
                if (rightArg is not null)
                    Args.Add(rightArg);
            }
            #endregion

            #region equals
            public bool Equals(FilterExpressionSetElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (!Args.SequenceEqual(obj.Args)) return false;
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
                    foreach (var exp in Args)
                        hash = (hash * multiplier) ^ (exp is not null ? exp.GetHashCode() : 0);
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
