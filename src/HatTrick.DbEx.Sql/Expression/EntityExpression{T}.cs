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

﻿using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EntityExpression<T> : 
        EntityExpression, 
        Entity<T>
        where T : class, IDbEntity
    {
        #region constructors
        private EntityExpression() : base(null, null, typeof(T), null, null)
        { 
        
        }

        protected EntityExpression(string identifier, string name, SchemaExpression schema, string alias)
            : base(identifier, name, typeof(T), schema, alias)
        {

        }
        #endregion

        #region interface
        SelectExpressionSet IEntityExpression<T>.BuildInclusiveSelectExpression()
            => GetInclusiveSelectExpression();
        SelectExpressionSet IEntityExpression<T>.BuildInclusiveSelectExpression(Func<string, string> alias)
            => GetInclusiveSelectExpression(alias);
        InsertExpressionSet<T> IEntityExpression<T>.BuildInclusiveInsertExpression(T entity)
            => GetInclusiveInsertExpression(entity);
        AssignmentExpressionSet IEntityExpression<T>.BuildAssignmentExpression(T target, T source)
            => GetAssignmentExpression(target, source);
        void IEntityExpression<T>.HydrateEntity(ISqlFieldReader reader, T entity)
            => HydrateEntity(reader, entity);
        #endregion

        #region methods
        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
        protected abstract SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias);
        protected abstract InsertExpressionSet<T> GetInclusiveInsertExpression(T entity);
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        protected abstract void HydrateEntity(ISqlFieldReader reader, T entity);
        #endregion
    }
}
