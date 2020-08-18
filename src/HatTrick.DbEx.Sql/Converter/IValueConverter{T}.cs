namespace HatTrick.DbEx.Sql.Converter
{
    public interface IValueConverter<T> : IConverter
    {
        T Convert(object value);
        object Convert(T value);
    }
}
