using System;
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Converter
{
    public class ValueConverter : IValueConverter
    {
        private Type type;

        public ValueConverter(Type type)
        {
            this.type = type;
        }

        public virtual (Type, object) ConvertToDatabase(object value)
        {
            if (type == value.GetType())
                return (type, value);

            return (type, Convert.ChangeType(value, type));
        }

        public virtual object ConvertFromDatabase(object value)
        {
            if (value is null)
                throw new DbExpressionException("Expected a non-null value from the database, but received a null value.");

            if (type == value.GetType())
                return value;

            return Convert.ChangeType(value, type);
        }

        public virtual T ConvertFromDatabase<T>(object value)
        {
            if (value is null)
                throw new DbExpressionException("Expected a non-null value from the database, but received a null value.");

            if (typeof(T) == value.GetType())
                return (T)value;
            
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
