using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class ObjectConverter : IValueConverter
    {
        public ObjectConverter()
        {

        }

        public virtual (Type, object) ConvertToDatabase(object value)
            => (typeof(object), value);

        public virtual object ConvertFromDatabase(object value)
            => value;

        public virtual T ConvertFromDatabase<T>(object value)
        {
            if (value is null)
                return default;

            return (T)Convert.ChangeType(value, typeof(object));
        }
    }
}
