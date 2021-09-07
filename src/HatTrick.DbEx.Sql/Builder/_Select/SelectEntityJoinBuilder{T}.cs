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

﻿using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectEntityJoinBuilder<TEntity> : SelectJoinExpressionBuilder<SelectEntityContinuation<TEntity>>,
        JoinOn<SelectEntityContinuation<TEntity>>,
        JoinOnWithAlias<SelectEntityContinuation<TEntity>>
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly SelectEntityContinuation<TEntity> caller;
        #endregion

        #region constructors
        public SelectEntityJoinBuilder(SelectQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, SelectEntityContinuation<TEntity> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> JoinOnWithAlias<SelectEntityContinuation<TEntity>>.As(string alias)
        {
            As(alias);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> JoinOn<SelectEntityContinuation<TEntity>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
