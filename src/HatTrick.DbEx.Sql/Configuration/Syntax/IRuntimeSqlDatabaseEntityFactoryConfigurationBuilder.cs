using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IRuntimeSqlDatabaseEntityFactoryConfigurationBuilder
    { 
        void UseThisToInstantiateNewEntities(IEntityFactory factory);

        void UseThisToInstantiateNewEntities<T>()
            where T : class, IEntityFactory, new();

        void UseThisToGetAFactoryForInstantiatingNewEntities<T>(Func<IEntityFactory> factory)
            where T : class, IDbEntity, new();
    }
}
