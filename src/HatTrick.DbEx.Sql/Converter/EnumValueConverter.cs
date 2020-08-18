using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class EnumValueConverter : IValueConverter
    {
        public virtual T Convert<T>(object value)
            => value is null ? default : (T)Enum.ToObject(typeof(T), value);

        public virtual object Convert<T>(T value)
            => value is DBNull ? default : System.Convert.ToInt32(value);
    }
}
