using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IMapperFactory
    {
       IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity;

        IValueMapProvider<T> CreateValueMapper<T>();

        IExpandoObjectMapper CreateExpandoObjectMapper();

        IValueMapper CreateValueMapper();
    }
}
