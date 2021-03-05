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

﻿using HatTrick.DbEx.Sql.Attribute;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression :
        IExpressionElement,
        IEquatable<ArithmeticExpression>
    {
        #region interface
        public IExpressionElement LeftArg { get; private set; }
        public IExpressionElement RightArg { get; private set; }
        public ArithmeticExpressionOperator ExpressionOperator { get; private set; }
        #endregion

        #region constructors
        public ArithmeticExpression(IExpressionElement leftArg, IExpressionElement rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
            ExpressionOperator = arithmeticOperator;
        }
        #endregion

        #region to string
        public override string ToString() => $"({LeftArg} {ExpressionOperator.GetArithmeticOperator()} {RightArg})";
        #endregion

        #region equals
        public bool Equals(ArithmeticExpression obj)
        {
            if (obj is null) return false;

            if (!ExpressionOperator.Equals(obj.ExpressionOperator)) return false;

            if (LeftArg is null && obj.LeftArg is object) return false;
            if (LeftArg is object && obj.LeftArg is null) return false;
            if (!LeftArg.Equals(obj.LeftArg)) return false;

            if (RightArg is null && obj.RightArg is object) return false;
            if (RightArg is object && obj.RightArg is null) return false;
            if (!RightArg.Equals(obj.RightArg)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is ArithmeticExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (LeftArg is object ? LeftArg.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (RightArg is object ? RightArg.GetHashCode() : 0);
                hash = (hash * multiplier) ^ ExpressionOperator.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
