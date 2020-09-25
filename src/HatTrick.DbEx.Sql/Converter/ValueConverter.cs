using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class ValueConverter : IValueConverter
    {
        public virtual object ConvertToDatabase(Type type, object value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            return Convert.ChangeType(value, type);
        }

        public virtual object ConvertFromDatabase(Type type, object value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            return Convert.ChangeType(value, type);
        }

        public virtual T ConvertFromDatabase<T>(object value)
        {
            if (value is null)
                return default;

            if (typeof(T) == value.GetType())
                return (T)value;

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
