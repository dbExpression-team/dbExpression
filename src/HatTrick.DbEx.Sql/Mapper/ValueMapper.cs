namespace HatTrick.DbEx.Sql.Mapper
{
    public class ValueMapper : IValueMapper
    {
        public IMapperFactory Factory { get; set; }

        public ValueMapper(IMapperFactory factory)
        {
            Factory = factory;
        }

        public T Map<T>(string name, object value)
            => Factory.CreateValueMapper<T>().Map(value);
    }
}
