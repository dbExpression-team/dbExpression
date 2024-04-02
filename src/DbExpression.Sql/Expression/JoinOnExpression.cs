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
    public class JoinOnExpression :
        IFilterExpressionElement,
        IEquatable<JoinOnExpression>
    {
        #region interface
        public IExpressionElement LeftArg { get; private set; }
        public IExpressionElement RightArg { get; private set; }
        public FilterExpressionOperator ExpressionOperator { get; private set; }
        public bool Negate { get; private set; }
        #endregion

        #region constructors
        public JoinOnExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator)
            : this(leftArg, rightArg, filterExpressionOperator, false)
        {
        }

        public JoinOnExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator expresionOperator, bool negate)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ExpressionOperator = expresionOperator;
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
        public bool Equals(JoinOnExpression? obj)
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
            => obj is JoinOnExpression exp && base.Equals(exp);

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

        #region negation operator
        public static JoinOnExpression operator !(JoinOnExpression joinOn)
        {
            joinOn.Negate = !joinOn.Negate;
            return joinOn;
        }
        #endregion
    }
}
