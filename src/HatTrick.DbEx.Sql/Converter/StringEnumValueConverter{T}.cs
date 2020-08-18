using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class StringEnumValueConverter<U> : EnumValueConverter
        where U : Enum
    {
        public override T Convert<T>(object value)
            => value is null ? default : (T)Enum.Parse(typeof(T), value as string);

        public override object Convert<T>(T value)
            => Enum.ToObject(typeof(U), value).ToString();
    }
}
