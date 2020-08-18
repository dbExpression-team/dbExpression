using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IMapperFactory
    {
        IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity;
        IExpandoObjectMapper CreateExpandoObjectMapper();
    }
}
