namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IValueMapper
    {
        T Map<T>(string name, object value);
    }
}
