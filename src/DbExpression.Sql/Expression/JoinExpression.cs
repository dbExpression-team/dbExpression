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
using System.Linq;

namespace DbExpression.Sql.Expression
{
    public class JoinExpression : 
        IExpressionElement, 
        IExpressionAliasProvider,
        IEquatable<JoinExpression>
    {
        #region interface
        public AnyJoinOnExpression? JoinOnExpression { get; private set; }
        public IExpressionElement JoinToo { get; private set; }
        public JoinOperationExpressionOperator JoinType { get; private set; }
        private string? alias;
        string? IExpressionAliasProvider.Alias => alias;
        #endregion

        #region constructors
        public JoinExpression(IExpressionElement joinToo, JoinOperationExpressionOperator joinType, AnyJoinOnExpression? onCondition)
            : this(joinToo, joinType, onCondition, null)
        {

        }

        protected JoinExpression(IExpressionElement joinToo, JoinOperationExpressionOperator joinType, AnyJoinOnExpression? onCondition, string? alias)
        {
            JoinToo = joinToo ?? throw new ArgumentNullException(nameof(joinToo));
            JoinType = joinType;
            JoinOnExpression = onCondition;
            if (joinType != JoinOperationExpressionOperator.CROSS && onCondition is null)
                throw new ArgumentNullException(nameof(onCondition));
            this.alias = alias;
        }
        #endregion

        #region as
        public JoinExpression As(string alias)
            => new(this.JoinToo, this.JoinType, this.JoinOnExpression, alias);
        #endregion

        #region to string
        public override string? ToString()
        {
            var joinToo = JoinToo.ToString();
            if (JoinToo is QueryExpression)
                joinToo = $"({joinToo})";
            if (JoinType == JoinOperationExpressionOperator.CROSS)
                return $"{JoinType} JOIN {joinToo}";
            return $"{JoinType} JOIN {joinToo} ON {JoinOnExpression}";
        }
        #endregion

        #region equals
        public bool Equals(JoinExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (JoinType != obj.JoinType) return false;

            if (alias is null && obj.alias is not null) return false;
            if (alias is not null && obj.alias is null) return false;
            if (alias is not null && !alias.Equals(obj.alias)) return false;

            if (JoinOnExpression is null && obj.JoinOnExpression is not null) return false;
            if (JoinOnExpression is not null && obj.JoinOnExpression is null) return false;
            if (JoinOnExpression is not null && !JoinOnExpression.Equals(obj.JoinOnExpression)) return false;

            if (JoinToo is null && obj.JoinToo is not null) return false;
            if (JoinToo is not null && obj.JoinToo is null) return false;
            if (JoinToo is not null && !JoinToo.Equals(obj.JoinToo)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is JoinExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ JoinType.GetHashCode();
                hash = (hash * multiplier) ^ (alias is not null ? alias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (JoinOnExpression is not null ? JoinOnExpression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (JoinToo is not null ? JoinToo.GetHashCode() : 0);

                return hash;
            }
        }
        #endregion

        #region logical & operator
        public static JoinExpressionSet? operator &(JoinExpression? a, JoinExpression? b)
        {
            if (a is null && b is not null) return new(b);
            if (a is not null && b is null) return new(a);
            if (a is null && b is null) return null;

            return new JoinExpressionSet(a!, b!);
        }

        #region implicit assignment expression set operator
        public static implicit operator JoinExpressionSet(JoinExpression a) => new(a);
        #endregion
        #endregion
    }

}
