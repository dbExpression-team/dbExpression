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

﻿using DbExpression.Sql.Builder;
using DbExpression.Sql.Expression;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntities<TDatabase, TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        IContinuationExpressionBuilder<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct the INTO clause of a sql INSERT query expression for inserting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/insert-statement">read the docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="InsertEntitiesTermination{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql INSERT query expression for inserting <typeparamref name="TEntity"/> entities.</returns>
        InsertEntitiesTermination<TDatabase, TEntity> Into(Table<TEntity> entity);
    }
}
