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

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertAssemblyPipelineEventContext : AfterAssemblyPipelineEventContext, IPipelineEventContext
    {
        #region internals
        private readonly InsertQueryExpression _expression;
        private readonly IDbEntity _entity;
        #endregion

        #region interface
        public new InsertQueryExpression Expression => _expression;
        public Type EntityType => _entity.GetType();
        #endregion

        #region constructors
        public AfterInsertAssemblyPipelineEventContext(InsertQueryExpression expression, ISqlParameterBuilder parameterBuilder, SqlStatement statement, IDbEntity entity)
            : base(expression, parameterBuilder, statement)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        public TEntity? GetEntity<TEntity>()
            where TEntity : class, IDbEntity
            => _entity as TEntity;

        public IEnumerable<TEntity> GetEntities<TEntity>()
            where TEntity : class, IDbEntity
            => _expression.Inserts.Values.Cast<TEntity>();
        #endregion
    }
}
