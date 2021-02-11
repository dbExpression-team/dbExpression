using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IMapperFactoryContinuationConfigurationBuilder
    {
        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="mapping">The delegate that iterates a field reader and maps the field values to <typeparamref name="TEntity"/> properties.</typeparam>
        IMapperFactoryContinuationConfigurationBuilder OverrideForEntity<TEntity>(Action<ISqlFieldReader, TEntity> mapping)
            where TEntity : class, IDbEntity;        
    }
}
