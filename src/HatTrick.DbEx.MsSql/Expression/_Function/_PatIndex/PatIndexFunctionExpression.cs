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
    public abstract class PatIndexFunctionExpression : ConversionFunctionExpression,
        IExpressionProvider<IExpressionElement>,
        IExpressionProvider<AnyStringElement>,
        IEquatable<PatIndexFunctionExpression>
    {
        #region internals
        private readonly AnyStringElement pattern;
        private readonly IExpressionElement expression;
        #endregion

        #region interface
        AnyStringElement IExpressionProvider<AnyStringElement>.Expression => pattern;
        IExpressionElement IExpressionProvider<IExpressionElement>.Expression => expression;
        #endregion

        #region constructors
        protected PatIndexFunctionExpression(AnyStringElement pattern, IExpressionElement expression, Type convertToType)
            : base(convertToType)
        {
            this.pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion

        #region to string
        public override string ToString() => $"PATINDEX({pattern}, {expression})";
        #endregion

        #region equals
        public bool Equals(PatIndexFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (pattern is null && obj.pattern is object) return false;
            if (pattern is object && obj.pattern is null) return false;
            if (!pattern.Equals(obj.pattern)) return false;

            if (expression is null && obj.expression is object) return false;
            if (expression is object && obj.expression is null) return false;
            if (!expression.Equals(obj.expression)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is PatIndexFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (pattern is object ? pattern.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (expression is object ? expression.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
