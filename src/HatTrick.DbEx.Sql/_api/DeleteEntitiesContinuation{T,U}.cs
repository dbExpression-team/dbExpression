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
    public interface DeleteEntitiesContinuation<TDatabase, TEntity> : DeleteEntitiesTermination<TDatabase, TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct the WHERE clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/delete-statement">read the docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <param name="where">Any filter predicate of type <see cref="AnyWhereExpression"/>.</param>
        /// <returns><see cref="DeleteEntitiesContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        DeleteEntitiesContinuation<TDatabase, TEntity> Where(AnyWhereExpression where);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> InnerJoin(AnyEntity entity);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> InnerJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> LeftJoin(AnyEntity entity);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> LeftJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> RightJoin(AnyEntity entity);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql DELETE query expression for a list of <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> RightJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql DELETE query expression for a list of <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> FullJoin(AnyEntity entity);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="WithAlias{JoinOn{DeleteEntitiesContinuation{TDatabase, TEntity}}}"/>, a fluent continuation for the construction of a sql JOIN expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> FullJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an CROSS JOIN clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/join">read the docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="DeleteEntitiesContinuation{TDatabase, TEntity}"/>, a fluent continuation for the construction of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.</returns>
        DeleteEntitiesContinuation<TDatabase, TEntity> CrossJoin(AnyEntity entity);
    }
}
