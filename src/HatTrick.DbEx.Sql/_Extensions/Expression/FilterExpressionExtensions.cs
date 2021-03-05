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

﻿namespace HatTrick.DbEx.Sql.Expression
{
    internal static class FilterExpressionExtensions
    {
        internal static JoinOnExpressionSet ConvertToJoinOnExpressionSet(this FilterExpression filter)
        {
            return ConvertToJoinOnExpressionSet(new FilterExpressionSet(filter));
        }

        internal static JoinOnExpressionSet ConvertToJoinOnExpressionSet(this FilterExpressionSet filterSet)
        {
            return ConvertToJoinOnExpressionSet(filterSet.LeftArg, filterSet.RightArg, filterSet.ConditionalOperator, filterSet.Negate);
        }

        private static JoinOnExpressionSet ConvertToJoinOnExpressionSet(IExpressionElement leftArg, IExpressionElement rightArg, ConditionalExpressionOperator conditionalOperator, bool negate)
        {
            //left
            if (leftArg is FilterExpressionSet leftSet)
            {
                leftArg = leftSet.ConvertToJoinOnExpressionSet();
            }
            else if (leftArg is FilterExpression leftExp)
            {
                leftArg = new JoinOnExpression(leftExp.LeftArg, leftExp.RightArg, leftExp.ExpressionOperator);
            }

            //right
            if (rightArg is FilterExpressionSet rightSet)
            {
                rightArg = rightSet.ConvertToJoinOnExpressionSet();
            }
            else if (rightArg is FilterExpression rightExp)
            {
                rightArg = new JoinOnExpression(rightExp.LeftArg, rightExp.RightArg, rightExp.ExpressionOperator);
            }

            return new JoinOnExpressionSet(leftArg, rightArg, conditionalOperator, negate);
        }
    }
}
