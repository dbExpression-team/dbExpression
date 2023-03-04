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

using HatTrick.DbEx.Sql.Builder;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntity<TDatabase, TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        IContinuationExpressionBuilder<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct the INTO clause of a sql INSERT query expression for inserting a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/insert-statement">read the docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entity">The database representation of the entity, for example "dbo.<typeparamref name="TEntity"/>" when the entity is of type <typeparamref name="TEntity"/>.</param>
        /// <returns><see cref="InsertEntityTermination{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql INSERT query expression for inserting a <typeparamref name="TEntity"/> entity.</returns>
        InsertEntityTermination<TDatabase, TEntity> Into(Table<TEntity> entity);
    }
}
