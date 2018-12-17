using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IValueMapper
    {
        T Map<T>(IExpressionMetadataProvider<FieldExpressionMetadata> field, object value);
    }
}
