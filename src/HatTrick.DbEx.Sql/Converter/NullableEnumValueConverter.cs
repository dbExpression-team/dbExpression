using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class NullableEnumValueConverter : EnumValueConverter
    {
        private Type type;

        public NullableEnumValueConverter(Type type) : base(Nullable.GetUnderlyingType(type))
        {
            this.type = type;
        }

        public override object ConvertFromDatabase(object value)
            => value is object ? base.ConvertFromDatabase(value) : default;

        public override T ConvertFromDatabase<T>(object value)
            => value is object ? (T)Enum.ToObject(Nullable.GetUnderlyingType(typeof(T)), value) : default;

        public override object ConvertToDatabase(object value)
        {
            if (value is null)
                return DBNull.Value;
            
            return Convert.ToInt32(value);
        }
    }
}
