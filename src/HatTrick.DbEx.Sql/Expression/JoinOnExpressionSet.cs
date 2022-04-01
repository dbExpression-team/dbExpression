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
    public class JoinOnExpressionSet :
        AnyJoinOnClause
    {
        #region interface
        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public IExpressionElement LeftArg { get; set; }
        public IExpressionElement? RightArg { get; set; }
        public bool IsSingleFilter => RightArg is null;
        public object? SingleFilter => RightArg is null ? LeftArg : null;
        #endregion

        #region constructors
        public JoinOnExpressionSet(JoinOnExpression singleJoin)
        {
            LeftArg = singleJoin ?? throw new ArgumentNullException(nameof(singleJoin));
        }

        protected JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ConditionalOperator = conditionalOperator;
        }

        protected JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpressionSet rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ConditionalOperator = conditionalOperator;
        }

        public JoinOnExpressionSet(IExpressionElement leftArg, IExpressionElement rightArg, ConditionalExpressionOperator conditionalOperator, bool negate)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg)); ;
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg)); ;
            ConditionalOperator = conditionalOperator;
            Negate = negate;
        }
        #endregion

        #region to string
        public override string? ToString() => (Negate) ? $"NOT ({LeftArg} {ConditionalOperator} {RightArg})" : $"{LeftArg} {ConditionalOperator} {RightArg}";

        #endregion

        #region conditional &, | operators
        public static JoinOnExpressionSet operator &(JoinOnExpressionSet? a, JoinOnExpression? b)
            => Operator(a, b, ConditionalExpressionOperator.And);

        public static JoinOnExpressionSet operator &(JoinOnExpressionSet? a, JoinOnExpressionSet? b)
            => Operator(a, b, ConditionalExpressionOperator.And);

        public static JoinOnExpressionSet operator |(JoinOnExpressionSet? a, JoinOnExpression? b)
            => Operator(a, b, ConditionalExpressionOperator.Or);

        public static JoinOnExpressionSet operator |(JoinOnExpressionSet? a, JoinOnExpressionSet? b)
            => Operator(a, b, ConditionalExpressionOperator.Or);

        private static JoinOnExpressionSet Operator(JoinOnExpressionSet? a, JoinOnExpression? b, ConditionalExpressionOperator expressionOperator)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            return b is null ? a! : new(a!, b!, expressionOperator);
        }

        private static JoinOnExpressionSet Operator(JoinOnExpressionSet? a, JoinOnExpressionSet? b, ConditionalExpressionOperator expressionOperator)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            return a is not null &&  b is not null ? new JoinOnExpressionSet(a, b, expressionOperator) : (a ?? b)!;
        }
        #endregion

        #region negation operator
        public static JoinOnExpressionSet operator !(JoinOnExpressionSet a)
        {
            a.Negate = !a.Negate;
            return a;
        }
        #endregion
    }

}
