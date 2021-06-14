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

﻿using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class InsertQueryExpressionBuilder<TEntity> : QueryExpressionBuilder,
        InsertEntity<TEntity>,
        InsertEntities<TEntity>,
        InsertEntityTermination<TEntity>,
        InsertEntitiesTermination<TEntity>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly InsertQueryExpression expression;
        private readonly IEnumerable<TEntity> instances;
        #endregion

        #region constructors
        protected InsertQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<TEntity> instances, InsertQueryExpression expression) : base(configuration, expression)
        {
            this.expression = expression;
            this.instances = instances;
        }
        #endregion

        #region methods
        InsertEntityTermination<TEntity> InsertEntity<TEntity>.Into(Entity<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        InsertEntitiesTermination<TEntity> InsertEntities<TEntity>.Into(Entity<TEntity> entity)
        {
            Into(entity);
            return this;
        }

        protected virtual void Into(Entity<TEntity> entity)
        {
            var i = 0;
            var insertEntity = entity as IEntityExpression<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression<TEntity>)}.");
            expression.BaseEntity = entity as EntityExpression<TEntity>;
            expression.Inserts = instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, insertEntity.BuildInclusiveInsertExpression(x).Expressions));
            expression.Outputs = insertEntity.BuildInclusiveSelectExpression().Expressions.Select(x => x.AsFieldExpression()).ToList();
        }
        #endregion
    }
}
