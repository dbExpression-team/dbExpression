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

using HatTrick.DbEx.Sql.Executor;

namespace HatTrick.DbEx.Sql.Expression
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

        protected EntityExpression(string identifier, string name, Schema schema, string? alias)
            : base(identifier, name, typeof(T), schema, alias)
        {

        }
        #endregion

        #region interface
        AssignmentExpressionSet Table<T>.BuildAssignmentExpression(T target, T source)
            => GetAssignmentExpression(target, source);
        InsertExpressionSet<T> Table<T>.BuildInclusiveInsertExpression(T entity)
            => GetInclusiveInsertExpression(entity);
        void Table<T>.HydrateEntity(ISqlFieldReader reader, T entity)
            => HydrateEntity(reader, entity);
        #endregion

        #region methods
        protected abstract InsertExpressionSet<T> GetInclusiveInsertExpression(T entity);
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        protected abstract void HydrateEntity(ISqlFieldReader reader, T entity);
        #endregion
    }
}
