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

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface DeleteEntities<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Construct a TOP clause for a sql DELETE query expression to limit the number of entities deleted.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/delete-statement">read the docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <param name="value">The maximum number of records to select from the database.</param>
        /// <returns><see cref="DeleteEntities"/>, a fluent continuation for constructing a sql DELETE query expression.</returns>
        DeleteEntities<TDatabase> Top(int value);

        /// <summary>
        /// Construct the FROM clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/delete-statement">read the docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <param name="entity">The database representation of the entity, for example "dbo.<typeparamref name="TEntity"/>" when the entity is of type <typeparamref name="TEntity"/>.</param>
        /// <returns><see cref="DeleteEntitiesContinuation{TEntity}"/>, a fluent continuation for the construction of a sql DELETE query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        DeleteEntitiesContinuation<TDatabase, TEntity> From<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
