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
using System.Text;
using System.Xml.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public sealed class QueryExpressionContinuationExpression :
        IExpressionElement,
        IEquatable<QueryExpressionContinuationExpression>
    {
        #region interface
        public QueryExpression Expression { get; private set; }
        public IExpressionElement ContinuationExpression { get; private set; }
        #endregion

        #region constructors
        public QueryExpressionContinuationExpression(QueryExpression expression, IExpressionElement link)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            ContinuationExpression = link ?? throw new ArgumentNullException(nameof(link));
        }
        #endregion

        #region to string
        public override string? ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Expression);
            sb.Append(' ');
            sb.Append(ContinuationExpression);
            sb.Append(' ');
            return sb.ToString();
        }
        #endregion

        #region operators
        public static bool operator ==(QueryExpressionContinuationExpression? obj1, QueryExpressionContinuationExpression? obj2)
        {
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2);
        }

        public static bool operator !=(QueryExpressionContinuationExpression? obj1, QueryExpressionContinuationExpression? obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(QueryExpressionContinuationExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!Expression.Equals(obj.Expression)) return false;
            if (!ContinuationExpression.Equals(obj.ContinuationExpression)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is QueryExpressionContinuationExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is not null ? Expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (ContinuationExpression is not null ? ContinuationExpression.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
