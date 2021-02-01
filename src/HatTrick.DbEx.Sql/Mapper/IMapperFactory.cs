using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IMapperFactory
    {
        IEntityMapper<TEntity> CreateEntityMapper<TEntity>(EntityExpression<TEntity> entity)
            where TEntity : class, IDbEntity;
        IExpandoObjectMapper CreateExpandoObjectMapper();
    }
}
