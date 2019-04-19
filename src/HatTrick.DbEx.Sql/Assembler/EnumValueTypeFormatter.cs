using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EnumValueTypeFormatter : IValueTypeFormatter
    {
        public string Format(object value) => Convert.ToInt32(value).ToString();
    }
}
