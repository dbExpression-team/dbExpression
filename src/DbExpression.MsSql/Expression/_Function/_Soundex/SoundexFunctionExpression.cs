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

using DbExpression.Sql;
using DbExpression.Sql.Expression;
using System;

namespace DbExpression.MsSql.Expression
{
    public abstract class SoundexFunctionExpression : StringFunctionExpression,
        IExpressionProvider<IExpressionElement>,
        IEquatable<SoundexFunctionExpression>
    {
        #region internals
        private readonly IExpressionElement expression;
        #endregion

        #region interface
        IExpressionElement IExpressionProvider<IExpressionElement>.Expression => expression;
        #endregion

        #region constructors
        protected SoundexFunctionExpression(IExpressionElement expression, Type convertToType)
            : base(convertToType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion

        #region to string
        public override string? ToString() => $"Soundex({expression})";
        #endregion

        #region equals
        public bool Equals(SoundexFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return expression.Equals(obj.expression);
        }

        public override bool Equals(object? obj)
         => obj is SoundexFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ expression.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
