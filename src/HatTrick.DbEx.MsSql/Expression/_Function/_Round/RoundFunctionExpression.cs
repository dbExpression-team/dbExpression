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
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Expression
{
    public abstract class RoundFunctionExpression : MathematicalFunctionExpression,
        IExpressionProvider<RoundFunctionExpression.RoundFunctionExpressionElements>,
        IEquatable<RoundFunctionExpression>
    {
        #region internals
        private readonly RoundFunctionExpressionElements expression;
        #endregion

        #region interface
        RoundFunctionExpressionElements IExpressionProvider<RoundFunctionExpressionElements>.Expression => expression;
        #endregion

        #region constructors
        protected RoundFunctionExpression(IExpressionElement expression, IExpressionElement length, Type declaredType) : base(declaredType)
        {
            this.expression = new RoundFunctionExpressionElements(expression ?? throw new ArgumentNullException(nameof(expression)), length ?? throw new ArgumentNullException(nameof(length)), null);
        }

        protected RoundFunctionExpression(IExpressionElement expression, IExpressionElement length, IExpressionElement? function, Type declaredType) : base(declaredType)
        {
            this.expression = new RoundFunctionExpressionElements(expression ?? throw new ArgumentNullException(nameof(expression)), length ?? throw new ArgumentNullException(nameof(length)), function);
        }
        #endregion

        #region to string
        public override string ToString() => $"ROUND({expression.Expression}, {expression.Length}{(expression.Function is object ? $", {expression.Function}" : string.Empty)})";
        #endregion

        #region equals
        public bool Equals(RoundFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (expression is null && obj.expression is not null) return false;
            if (expression is not null && obj.expression is null) return false;
            if (expression is not null && !expression.Equals(obj.expression)) return false;

            return true;
        }

        public override bool Equals(object? obj)
         => obj is RoundFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (expression is object ? expression.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class RoundFunctionExpressionElements : IExpressionElement,
            IEquatable<RoundFunctionExpressionElements>
        {
            #region interface
            public IExpressionElement Expression { get; private set; }
            public IExpressionElement Length { get; private set; }
            public IExpressionElement? Function { get; private set; }
            #endregion

            #region constructors
            public RoundFunctionExpressionElements(IExpressionElement expression, IExpressionElement length, IExpressionElement? function)
            {
                this.Expression = expression ?? throw new ArgumentNullException(nameof(expression));
                this.Length = length ?? throw new ArgumentNullException(nameof(length));
                this.Function = function;
            }
            #endregion

            #region equals
            public bool Equals(RoundFunctionExpressionElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (Expression is null && obj.Expression is not null) return false;
                if (Expression is not null && obj.Expression is null) return false;
                if (Expression is not null && !Expression.Equals(obj.Expression)) return false;

                if (Length is null && obj.Length is not null) return false;
                if (Length is not null && obj.Length is null) return false;
                if (Length is not null && !Length.Equals(obj.Length)) return false;

                if (Function is null && obj.Function is not null) return false;
                if (Function is not null && obj.Function is null) return false;
                if (Function is not null && !Function.Equals(obj.Function)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is RoundFunctionExpressionElements && Equals(obj);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (Expression is object ? Expression.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Length is object ? Length.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Function is object ? Function.GetHashCode() : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
