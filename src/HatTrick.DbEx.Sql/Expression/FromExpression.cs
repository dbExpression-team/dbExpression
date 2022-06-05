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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FromExpression :
        IExpressionElement,
        IExpressionAliasProvider,
        IEquatable<FromExpression>
    {
        #region interface
        public IExpressionElement Expression { get; private set; }
        private string? alias;
        string? IExpressionAliasProvider.Alias => alias;
        #endregion

        #region constructors
        public FromExpression(IExpressionElement expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion

        #region as
        public FromExpression As(string alias)
        {
            this.alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string? ToString()
        {
            var value = Expression is QueryExpression ? $"({Expression})" : Expression.ToString();
            if (!string.IsNullOrWhiteSpace(alias))
                return $"{value} AS {alias}";
            return value;
        }
        #endregion

        #region equals
        public bool Equals(FromExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (Expression != obj.Expression) return false;

            if (alias is null && obj.alias is not null) return false;
            if (alias is not null && obj.alias is null) return false;
            if (alias is not null && !alias.Equals(obj.alias)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is FromExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ Expression.GetHashCode();
                hash = (hash * multiplier) ^ (alias is not null ? alias.GetHashCode() : 0);

                return hash;
            }
        }
        #endregion
    }

}
