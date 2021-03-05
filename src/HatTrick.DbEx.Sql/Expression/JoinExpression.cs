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
    public class JoinExpression : 
        IExpressionElement, 
        IExpressionAliasProvider
    {
        #region interface
        public AnyJoinOnClause JoinOnExpression { get; private set; }
        public IExpressionElement JoinToo { get; private set; }
        public JoinOperationExpressionOperator JoinType { get; private set; }
        private string Alias { get; set; }
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        public JoinExpression(IExpressionElement joinToo, JoinOperationExpressionOperator joinType, AnyJoinOnClause onCondition)
            : this(joinToo, joinType, onCondition, null)
        {

        }

        protected JoinExpression(IExpressionElement joinToo, JoinOperationExpressionOperator joinType, AnyJoinOnClause onCondition, string alias)
        {
            JoinToo = joinToo ?? throw new ArgumentNullException(nameof(joinToo));
            JoinType = joinType;
            JoinOnExpression = onCondition ?? throw new ArgumentNullException(nameof(onCondition));
            Alias = alias;
        }
        #endregion

        #region as
        public JoinExpression As(string alias)
            => new JoinExpression(this.JoinToo, this.JoinType, this.JoinOnExpression, alias);
        #endregion

        #region to string
        public override string ToString() => JoinType == JoinOperationExpressionOperator.CROSS ? $"{JoinType} JOIN {JoinToo}" : $"{JoinType} JOIN {JoinToo} ON {JoinOnExpression}";
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpression a, JoinExpression b)
        {
            if (a is null && b is object) { return new JoinExpressionSet(b); }
            if (a is object && b is null) { return new JoinExpressionSet(a); }
            if (a is null && b is null) { return null; }

            return new JoinExpressionSet(a, b);
        }
        #endregion
    }
    
}
