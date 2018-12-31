using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IValueMapper
    {
        T Map<T>(IDbExpressionMetadataProvider<ISqlFieldMetadata> field, object value);
    }
}
