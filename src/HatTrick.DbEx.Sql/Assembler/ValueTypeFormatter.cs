using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ValueTypeFormatter : IValueTypeFormatter
    {
        public string Format(object value) => value.ToString();
    }
}
