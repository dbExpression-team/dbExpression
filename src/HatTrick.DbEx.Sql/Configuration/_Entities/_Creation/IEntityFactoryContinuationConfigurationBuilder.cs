using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IEntityFactoryContinuationConfigurationBuilder
    {
        /// <summary>
        /// Override the default behaviour of creating a new <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <typeparam name="entityFactory">The delegate responsible for creating an instance of a <typeparamref name="TEntity"/>.</param>
        IEntityFactoryContinuationConfigurationBuilder OverrideForEntity<TEntity>(Func<TEntity> entityFactory)
            where TEntity : class, IDbEntity;
    }
}
