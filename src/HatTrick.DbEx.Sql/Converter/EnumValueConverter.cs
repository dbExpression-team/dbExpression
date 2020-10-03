using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class EnumValueConverter : IValueConverter
    {
        private Type type;

        public EnumValueConverter(Type type)
        {
            this.type = type;
        }

        public virtual object ConvertFromDatabase(object value)
            => Enum.ToObject(type, value);

        public virtual T ConvertFromDatabase<T>(object value)
            => (T)Enum.ToObject(typeof(T), value);

        public virtual object ConvertToDatabase(object value)
            => Convert.ToInt32(value);
    }
}
