using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class NullableEnumValueConverter : EnumValueConverter
    {
        public override object ConvertFromDatabase(Type type, object value)
            => value is object ? base.ConvertFromDatabase(Nullable.GetUnderlyingType(type), value) : default;

        public override T ConvertFromDatabase<T>(object value)
            => value is object ? (T)Enum.ToObject(Nullable.GetUnderlyingType(typeof(T)), value) : default;

        public override object ConvertToDatabase(Type type, object value)
        {
            if (value is null)
                return DBNull.Value;
            
            return Convert.ToInt32(value);
        }
    }
}
