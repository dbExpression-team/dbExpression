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
        {
            if (value is null)
                return default;

            if (value is string persistedAsString)
            {
                try
                {
                    return Enum.Parse(type, persistedAsString, true);
                }
                catch { }
            }
            return Enum.ToObject(type, value);
        }

        public virtual T ConvertFromDatabase<T>(object value)
        {
            if (value is null)
                return default;

            if (value is string persistedAsString)
            {
                try
                {
                    return (T)Enum.Parse(typeof(T), persistedAsString, true);
                }
                catch { }
            }
            return (T)Enum.ToObject(typeof(T), value);
        }

        public virtual (Type, object) ConvertToDatabase(object value)
            => (typeof(int), Convert.ToInt32(value));
    }
}
