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

﻿using DbExpression.Sql.Expression;
using System;
using System.Linq;

namespace DbExpression.Sql.Builder
{
    public class UpdateJoinExpressionBuilder<TDatabase, T>
        where TDatabase : class, ISqlDatabaseRuntime
        where T : IExpressionBuilder<TDatabase>
    {
        #region internals
        private readonly UpdateQueryExpression expression;
        private readonly IExpressionElement joinTo;
        private readonly JoinOperationExpressionOperator joinType;
        private string? alias;
        #endregion

        #region constructors
        public UpdateJoinExpressionBuilder(UpdateQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            this.joinTo = joinTo ?? throw new ArgumentNullException(nameof(joinTo));
            this.joinType = joinType;
        }
        #endregion

        #region methods
        protected void On(AnyJoinOnExpression joinOn)
        {
            var join = new JoinExpression(joinTo, joinType, joinOn);

            if (!string.IsNullOrWhiteSpace(alias))
                join = join.As(alias!);

            expression.Joins = expression.Joins is null ?
                new JoinExpressionSet(join)
                :
                new JoinExpressionSet(expression.Joins.Expressions.Concat(new JoinExpression[1] { join }));
        }

        protected void As(string alias)
            => this.alias = alias;
        #endregion
    }
}
