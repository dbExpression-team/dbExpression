using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IEntityFactory
    {
        void RegisterFactory(IEntityFactory factory);
        void RegisterFactory<T>(Func<T> factory)
            where T : class, IDbEntity;
        void RegisterDefaultFactories();
        T CreateEntity<T>() where T : class, IDbEntity, new();
    }
}
