using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class NullableValueConverter : IValueConverter
    {
        public virtual object ConvertToDatabase(Type type, object value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            var underlying = Nullable.GetUnderlyingType(type);
            if (underlying == type)
                return value;

            return Convert.ChangeType(value, underlying);
        }

        public virtual object ConvertFromDatabase(Type type, object value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            var underlying = Nullable.GetUnderlyingType(type);
            if (underlying == type)
                return value;
                
            return Convert.ChangeType(value, underlying);
        }

        public virtual T ConvertFromDatabase<T>(object value)
        {
            if (value is null)
                return default;

            if (typeof(T) == value.GetType())
                return (T)value;

            var underlying = Nullable.GetUnderlyingType(typeof(T));
            if (underlying == typeof(T))
                return (T)value;

            return (T)Convert.ChangeType(value, underlying);
        }
    }
}
