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

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FilterExpression :
        IFilterExpressionElement,
        AnyWhereClause,
        AnyJoinOnClause,
        AnyHavingClause,
        IEquatable<FilterExpression>
    {
        #region internals
        private static readonly Lazy<Dictionary<FilterExpressionOperator, string>> filterExpressionMap = new(() => typeof(FilterExpressionOperator).GetValuesAndFilterOperators().ToDictionary(k => k.Key, v => v.Value!));
        #endregion

        #region interface
        public IExpressionElement LeftArg { get; private set; }
        public IExpressionElement RightArg { get; private set; }
        public FilterExpressionOperator ExpressionOperator { get; private set; }
        public bool Negate { get; set; }
        #endregion

        #region constructors
        protected FilterExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator)
            : this(leftArg, rightArg, filterExpressionOperator, false)
        {

        }

        protected FilterExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator, bool negate)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ExpressionOperator = filterExpressionOperator;
            Negate = negate;
        }
        #endregion

        #region to string
        public override string? ToString()
        {
            string expression = $"{LeftArg} {filterExpressionMap.Value[ExpressionOperator]} {RightArg}";
            if (!Negate)
                return expression;
            return $" NOT ({expression})";
        }
        #endregion

        #region equals
        public bool Equals(FilterExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!LeftArg.Equals(obj.LeftArg)) return false;
            if (!RightArg.Equals(obj.RightArg)) return false;
            if (ExpressionOperator != obj.ExpressionOperator) return false;

            if (Negate != obj.Negate) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is FilterExpression exp && base.Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (LeftArg is not null ? LeftArg.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (RightArg is not null ? RightArg.GetHashCode() : 0);
                hash = (hash * multiplier) ^ ExpressionOperator.GetHashCode();
                hash = (hash * multiplier) ^ Negate.GetHashCode();
                return hash;
            }
        }
        #endregion

        #region conditional &, | operators
        public static FilterExpressionSet operator &(FilterExpression? a, FilterExpression? b)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            return new FilterExpressionSet((a ?? b)!, b ?? a, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpression? a, FilterExpression? b)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            return new FilterExpressionSet((a ?? b)!, b ?? a, ConditionalExpressionOperator.Or);
        }

        public static FilterExpressionSet operator &(FilterExpression? a, FilterExpressionSet? b)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            if (b is null) return new(a!);
            return new(a!, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpression? a, FilterExpressionSet? b)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            if (b is null) return new(a!);
            return new(a!, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region negation operator
        public static FilterExpression? operator !(FilterExpression? filter)
        {
            if (filter is not null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }    
}
