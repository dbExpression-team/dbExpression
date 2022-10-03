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

using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class EntitySelectSetQueryExpressionBuilder<TDatabase, TEntity> : SelectSetQueryExpressionBuilder<TDatabase>
       where TDatabase : class, ISqlDatabaseRuntime
       where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Table<TEntity> table;
        #endregion

        #region constructors
        public EntitySelectSetQueryExpressionBuilder(
            Func<SelectQueryExpression> queryExpressionFactory,
            Func<ISelectSetQueryExpressionExecutionPipeline> selectSetExecutionPipelineFactory,
            Func<ISelectQueryExpressionExecutionPipeline> selectExecutionPipelineFactory,
            Table<TEntity> table
        ) : base(queryExpressionFactory, selectSetExecutionPipelineFactory, selectExecutionPipelineFactory)
        {
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }
        #endregion

        #region methods
        protected override SelectEntities<TDatabase, T> CreateSelectEntitiesBuilder<T>()
        {
            if (typeof(TEntity) != typeof(T))
                throw new DbExpressionException($"Expected {typeof(T)} to be of type {typeof(TEntity)}");

            var exp = StartNew();
            exp.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionException($"Select expressions for entity {typeof(TEntity)} were not provided.");

            return (new SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity>(
                SelectQueryExpressionExecutionPipelineFactory,
                this,
                table
            ) as SelectEntities<TDatabase, T>)!;
        }

        protected override SelectEntity<TDatabase, T> CreateSelectEntityBuilder<T>()
        {
            if (typeof(TEntity) != typeof(T))
                throw new DbExpressionException($"Expected {typeof(T)} to be of type {typeof(TEntity)}");

            var exp = StartNew();
            exp.Select = table.BuildInclusiveSelectExpression() ?? throw new DbExpressionException($"Select expressions for entity {typeof(TEntity)} were not provided.");
            exp.Top = 1;

            return (new SelectEntitySelectQueryExpressionBuilder<TDatabase, TEntity>(
                SelectQueryExpressionExecutionPipelineFactory,
                this,
                table
            ) as SelectEntity<TDatabase, T>)!;
        }
        #endregion
    }
}
