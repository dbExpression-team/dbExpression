using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class NullableEnumValueConverter<T, U> : EnumValueConverter<T>
    {
        public override T Convert(object value)
            =>  value is null ? default : (T)Enum.ToObject(typeof(U), value);
    }
}
