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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class DeleteQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        DeleteEntities<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly DeleteQueryExpression _expression;
        protected override QueryExpression Expression => DeleteQueryExpression;
        public DeleteQueryExpression DeleteQueryExpression => _expression;
        #endregion

        #region constructors
        public DeleteQueryExpressionBuilder(DeleteQueryExpression expression, SqlDatabaseRuntimeConfiguration config)
            : base(config)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        protected DeleteQueryExpressionBuilder(DeleteQueryExpression expression, SqlDatabaseRuntimeConfiguration config, Table entity)
            : base(config)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _expression.From = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        DeleteEntitiesContinuation<TDatabase, TEntity> DeleteEntities<TDatabase>.From<TEntity>(Table<TEntity> entity)
            => CreateTypedBuilder(DeleteQueryExpression, Configuration, entity ?? throw new ArgumentNullException(nameof(entity)));

        /// <inheritdoc />
        DeleteEntities<TDatabase> DeleteEntities<TDatabase>.Top(int value)
        {
            DeleteQueryExpression.Top = value;
            return this;
        }

        protected virtual DeleteEntitiesContinuation<TDatabase, TEntity> CreateTypedBuilder<TEntity>(DeleteQueryExpression expression, SqlDatabaseRuntimeConfiguration configuration, Table<TEntity> entity)
            where TEntity : class, IDbEntity
            => new DeleteEntitiesDeleteQueryExpressionBuilder<TDatabase, TEntity>(expression, configuration, entity);

        protected virtual void ApplyWhere(AnyWhereClause expression)
        {
            if (expression is null)
                return;

            if (expression is FilterExpression single)
            {
                if (DeleteQueryExpression.Where is null)
                    DeleteQueryExpression.Where = new(single);
                else
                    DeleteQueryExpression.Where &= single;
            }
            else if (expression is FilterExpressionSet set)
            {
                if (expression is IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements> provider && provider.Expression?.Args is not null && provider.Expression.Args.Any())
                {
                    if (DeleteQueryExpression.Where is null)
                        DeleteQueryExpression.Where = set;
                    else
                        DeleteQueryExpression.Where &= set;
                }
            }
        }

        protected virtual void ApplyCrossJoin(AnyEntity entity)
        {
            DeleteQueryExpression.Joins = DeleteQueryExpression.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(DeleteQueryExpression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }
        #endregion
    }
}
