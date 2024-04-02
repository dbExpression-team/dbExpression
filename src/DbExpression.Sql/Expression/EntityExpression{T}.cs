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

using DbExpression.Sql.Executor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Expression
{
    public abstract class EntityExpression<T> :
        EntityExpression, 
        Table<T>
        where T : class, IDbEntity
    {
        #region constructors
        private EntityExpression()
        {

        }

        protected EntityExpression(int dbex_identifier, string dbex_name, Schema dbex_schema, string? dbex_alias)
            : base(dbex_identifier, dbex_name, typeof(T), dbex_schema, dbex_alias)
        {

        }
        #endregion

        #region interface
        AssignmentExpressionSet Table<T>.BuildAssignmentExpression(T target, T source, IEnumerable<Field> exclusions)
            => GetAssignmentExpression(target, source, exclusions?.Select(x => x?.GetType() ?? typeof(object)) ?? Enumerable.Empty<Type>());
        InsertExpressionSet<T> Table<T>.BuildInclusiveInsertExpression(T entity)
            => GetInclusiveInsertExpression(entity);
        void Table<T>.HydrateEntity(ISqlFieldReader reader, T entity)
            => HydrateEntity(reader, entity);
        #endregion

        #region methods
        protected abstract InsertExpressionSet<T> GetInclusiveInsertExpression(T entity);
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to, IEnumerable<Type> exlusions);
        protected abstract void HydrateEntity(ISqlFieldReader reader, T entity);
        #endregion
    }
}
