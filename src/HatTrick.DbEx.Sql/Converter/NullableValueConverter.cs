using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class NullableValueConverter : IValueConverter
    {
        private Type type;
        private Type underlyingType;

        public NullableValueConverter(Type type)
        {
            this.type = type;
            this.underlyingType = Nullable.GetUnderlyingType(type);
        }

        public virtual object ConvertToDatabase(object value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            if (type == underlyingType)
                return value;

            return Convert.ChangeType(value, underlyingType);
        }

        public virtual object ConvertFromDatabase(object value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            if (type == underlyingType)
                return value;
                
            return Convert.ChangeType(value, underlyingType);
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
