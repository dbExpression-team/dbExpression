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
    public abstract class ReplaceFunctionExpression : StringFunctionExpression,
        IExpressionProvider<ReplaceFunctionExpression.ReplaceFunctionExpressionElements>,
        IEquatable<ReplaceFunctionExpression>
    {
        #region internals
        private readonly ReplaceFunctionExpressionElements elements;
        #endregion

        #region interface
        ReplaceFunctionExpressionElements IExpressionProvider<ReplaceFunctionExpressionElements>.Expression => elements;
        #endregion

        #region constructors
        protected ReplaceFunctionExpression(IExpressionElement expression, IExpressionElement pattern, IExpressionElement replacement, Type convertToType)
            : base(convertToType)
        {
            this.elements = new ReplaceFunctionExpressionElements(expression, pattern, replacement);
        }
        #endregion

        #region to string
        public override string? ToString() => $"SUBSTRING({elements.Expression}, {elements.Pattern}, {elements.Replacement})";
        #endregion

        #region equals
        public bool Equals(ReplaceFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (elements is null && obj.elements is not null) return false;
            if (elements is not null && obj.elements is null) return false;
            if (elements is not null && !elements.Equals(obj.elements)) return false;

            return true;
        }

        public override bool Equals(object? obj)
         => obj is ReplaceFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (elements is not null ? elements.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class ReplaceFunctionExpressionElements : IExpressionElement,
            IEquatable<ReplaceFunctionExpressionElements>
        {
            #region interface
            public IExpressionElement Expression { get; private set; }
            public IExpressionElement Pattern { get; private set; }
            public IExpressionElement Replacement { get; private set; }
            #endregion

            #region constructors
            public ReplaceFunctionExpressionElements(IExpressionElement expression, IExpressionElement pattern, IExpressionElement replacement)
            {
                this.Expression = expression ?? throw new ArgumentNullException(nameof(expression));
                this.Pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
                this.Replacement = replacement ?? throw new ArgumentNullException(nameof(replacement));
            }
            #endregion

            #region equals
            public bool Equals(ReplaceFunctionExpressionElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (Expression is null && obj.Expression is not null) return false;
                if (Expression is not null && obj.Expression is null) return false;
                if (Expression is not null && !Expression.Equals(obj.Expression)) return false;

                if (Pattern is null && obj.Pattern is not null) return false;
                if (Pattern is not null && obj.Pattern is null) return false;
                if (Pattern is not null && !Pattern.Equals(obj.Pattern)) return false;

                if (Replacement is null && obj.Replacement is not null) return false;
                if (Replacement is not null && obj.Replacement is null) return false;
                if (Replacement is not null && !Replacement.Equals(obj.Replacement)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is ReplaceFunctionExpressionElements && Equals(obj);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (Expression is not null ? Expression.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Pattern is not null ? Pattern.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Replacement is not null ? Replacement.GetHashCode() : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
