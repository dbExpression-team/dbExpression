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
    public class UpdateEntitiesJoinBuilder<TDatabase, TEntity> : UpdateJoinExpressionBuilder<TDatabase, UpdateEntitiesContinuation<TDatabase, TEntity>>,
        JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>>,
        JoinOnWithAlias<UpdateEntitiesContinuation<TDatabase, TEntity>>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly UpdateEntitiesContinuation<TDatabase, TEntity> caller;
        #endregion

        #region constructors
        public UpdateEntitiesJoinBuilder(UpdateQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, UpdateEntitiesContinuation<TDatabase, TEntity> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>> JoinOnWithAlias<UpdateEntitiesContinuation<TDatabase, TEntity>>.As(string alias)
        {
            As(alias);
            return this;
        }

        /// <inheritdoc />
        UpdateEntitiesContinuation<TDatabase, TEntity> JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
