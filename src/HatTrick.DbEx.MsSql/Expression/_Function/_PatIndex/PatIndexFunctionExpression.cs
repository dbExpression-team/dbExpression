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

using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public abstract class PatIndexFunctionExpression : ConversionFunctionExpression,
        IExpressionProvider<PatIndexFunctionExpression.PatIndexFunctionExpressionElements>,
        IEquatable<PatIndexFunctionExpression>
    {
        #region internals
        private readonly PatIndexFunctionExpressionElements elements;
        #endregion

        #region interface
        PatIndexFunctionExpressionElements IExpressionProvider<PatIndexFunctionExpressionElements>.Expression => elements;
        #endregion

        #region constructors
        protected PatIndexFunctionExpression(IExpressionElement pattern, IExpressionElement expression, Type convertToType)
            : base(convertToType)
        {
            this.elements = new PatIndexFunctionExpressionElements(pattern, expression);
        }
        #endregion

        #region to string
        public override string ToString() => $"PATINDEX({elements.Pattern}, {elements.ToSearch})";
        #endregion

        #region equals
        public bool Equals(PatIndexFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (elements is null && obj.elements is object) return false;
            if (elements is object && obj.elements is null) return false;
            if (elements is object && !elements.Equals(obj.elements)) return false;

            return true;
        }

        public override bool Equals(object? obj)
         => obj is PatIndexFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (elements is object ? elements.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class PatIndexFunctionExpressionElements : IExpressionElement,
            IEquatable<PatIndexFunctionExpressionElements>
        {
            #region interface
            public IExpressionElement Pattern { get; private set; }
            public IExpressionElement ToSearch { get; private set; }
            #endregion

            #region constructors
            public PatIndexFunctionExpressionElements(IExpressionElement pattern, IExpressionElement toSearch)
            {
                this.Pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
                this.ToSearch = toSearch ?? throw new ArgumentNullException(nameof(toSearch));
            }
            #endregion

            #region equals
            public bool Equals(PatIndexFunctionExpressionElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (Pattern is null && obj.Pattern is object) return false;
                if (Pattern is object && obj.Pattern is null) return false;
                if (Pattern is object && !Pattern.Equals(obj.Pattern)) return false;

                if (ToSearch is null && obj.ToSearch is object) return false;
                if (ToSearch is object && obj.ToSearch is null) return false;
                if (ToSearch is object && !ToSearch.Equals(obj.ToSearch)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is PatIndexFunctionExpressionElements && Equals(obj);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (Pattern is object ? Pattern.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (ToSearch is object ? ToSearch.GetHashCode() : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
