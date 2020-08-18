using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class NullableEnumValueConverter<T, U> : EnumValueConverter<T>
    {
        public override T Convert(object value)
        {
            return value is null ? default
                : value is string ? (T)Enum.Parse(typeof(U), value as string)
                    : (T)Enum.ToObject(typeof(U), value);
        }
    }
}
