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

using DbExpression.Sql.Expression;
using System;

namespace DbExpression.Sql.Builder
{
    public class SelectValueJoinExpressionBuilder<TDatabase, TValue> : SelectJoinExpressionBuilder<TDatabase, SelectValueContinuation<TDatabase, TValue>>,
        JoinOn<SelectValueContinuation<TDatabase, TValue>>,
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly SelectValueContinuation<TDatabase, TValue> caller;
        #endregion

        #region constructors
        public SelectValueJoinExpressionBuilder(SelectQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, SelectValueContinuation<TDatabase, TValue> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>>.As(string alias)
        {
            As(alias);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> JoinOn<SelectValueContinuation<TDatabase, TValue>>.On(AnyJoinOnExpression joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
