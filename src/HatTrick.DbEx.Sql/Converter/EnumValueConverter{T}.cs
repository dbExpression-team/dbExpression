namespace HatTrick.DbEx.Sql.Converter
{
    public class EnumValueConverter<T> : EnumValueConverter, IValueConverter<T>
    {
        public virtual T Convert(object value) => base.Convert<T>(value);
        public virtual object Convert(T value) => base.Convert(value);
    }
}
