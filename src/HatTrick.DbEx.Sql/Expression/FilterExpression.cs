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
    public class FilterExpression :
        IFilterExpressionElement,
        IEquatable<FilterExpression>
    {
        #region interface
        public IExpressionElement LeftArg { get; private set; }
        public IExpressionElement? RightArg { get; private set; }
        public FilterExpressionOperator ExpressionOperator { get; private set; }
        public bool Negate { get; set; }
        #endregion

        #region constructors
        public FilterExpression(IExpressionElement leftArg)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
        }

        public FilterExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator)
            : this(leftArg, rightArg, filterExpressionOperator, false)
        {

        }

        public FilterExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator, bool negate)
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
            string expression = $"{LeftArg} {ExpressionOperator} {RightArg}";
            return (Negate) ? $" NOT ({expression})" : expression;
        }
        #endregion

        #region equals
        public bool Equals(FilterExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!LeftArg.Equals(obj.LeftArg)) return false;

            if (RightArg is null && obj.RightArg is not null) return false;
            if (RightArg is not null && obj.RightArg is null) return false;
            if (RightArg is not null && !RightArg.Equals(obj.RightArg)) return false;

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
            return b is null ? a! : new FilterExpressionSet(a!, b!, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpression? a, FilterExpression? b)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            return b is null ? a! : new FilterExpressionSet(a!, b!, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit operators
        public static implicit operator FilterExpressionSet(FilterExpression a) 
            => new(a);

        public static implicit operator HavingExpression(FilterExpression a) 
            => new(a);

        public static implicit operator JoinOnExpressionSet(FilterExpression a)
            => a.ConvertToJoinOnExpressionSet();
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
