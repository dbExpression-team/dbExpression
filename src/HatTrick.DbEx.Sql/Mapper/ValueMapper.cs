using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class ValueMapper : IValueMapper
    {
        public IMapperFactory Factory { get; set; }

        public ValueMapper(IMapperFactory factory)
        {
            Factory = factory;
        }

        public T Map<T>(IExpressionMetadataProvider<FieldExpressionMetadata> field, object value)
            => Factory.CreateValueMapper<T>().Map(value);
    }
}
