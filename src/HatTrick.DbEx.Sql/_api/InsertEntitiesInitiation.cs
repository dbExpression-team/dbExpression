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

using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntitiesInitiation<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Start constructing a sql INSERT query expression to insert a record.  Property values from the <paramref name="entity"/> instance are used to create the record values for the INSERT statement. 
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entity">The entity supplying the property values.
        /// </param>
        /// <returns><see cref="InsertEntity{TDatabase, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entity to insert.</typeparam>
        InsertEntity<TDatabase, TEntity> Insert<TEntity>(TEntity entity)
            where TEntity : class, IDbEntity;

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{TDatabase, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        InsertEntities<TDatabase, TEntity> InsertMany<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity;

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{TDatabase, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        InsertEntities<TDatabase, TEntity> InsertMany<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IDbEntity;

    }
}
