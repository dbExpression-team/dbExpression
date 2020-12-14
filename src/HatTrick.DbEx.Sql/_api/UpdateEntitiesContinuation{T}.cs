using HatTrick.DbEx.Sql.Builder;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateEntitiesContinuation<TEntity> : UpdateEntitiesTermination<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct the WHERE clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/search-condition-transact-sql">Microsoft docs on search condition for UPDATE</see>
        /// </para>
        /// </summary>
        /// <param name="where">Any filter predicate of type <see cref="AnyWhereClause"/>.</param>
        /// <returns><see cref="UpdateEntitiesContinuation{TEntity}"/>, a fluent continuation for the construction of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.</returns>
        UpdateEntitiesContinuation<TEntity> Where(AnyWhereClause where);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<UpdateEntitiesContinuation<TEntity>> InnerJoin(AnyEntity entity);

        /// <summary>
        /// Construct an INNER JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="JoinOnWithAlias{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> InnerJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<UpdateEntitiesContinuation<TEntity>> LeftJoin(AnyEntity entity);

        /// <summary>
        /// Construct an LEFT JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="JoinOnWithAlias{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> LeftJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<UpdateEntitiesContinuation<TEntity>> RightJoin(AnyEntity entity);

        /// <summary>
        /// Construct an RIGHT JOIN clause of a sql SELECT query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="JoinOnWithAlias{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> RightJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<UpdateEntitiesContinuation<TEntity>> FullJoin(AnyEntity entity);

        /// <summary>
        /// Construct an FULL JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="subquery">Any expression of type <see cref="AnySelectSubquery"/> specifying a SELECT query expression to join to.</param>
        /// <returns><see cref="JoinOnWithAlias{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> FullJoin(AnySelectSubquery subquery);

        /// <summary>
        /// Construct an CROSS JOIN clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="entity">Any expression of type <see cref="AnyEntity"/> specifying the database entity to join to.</param>
        /// <returns><see cref="JoinOn{UpdateEntitiesContinuation{TEntity}}"/>, a fluent continuation for the construction of a sql JOIN expression for updating <typeparamref name="TEntity"/> entities.</returns>
        JoinOn<UpdateEntitiesContinuation<TEntity>> CrossJoin(AnyEntity entity);
    }
}
