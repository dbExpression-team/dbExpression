using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IEntityFactory
    {
        void RegisteFactory<T>(IEntityFactory factory)
            where T : class, IDbEntity;
        void RegisterFactory<T>(Func<IEntityFactory> factory)
            where T : class, IDbEntity;
        void RegisterDefaultFactories();
        T CreateEntity<T>() where T : class, IDbEntity, new();
    }
}
