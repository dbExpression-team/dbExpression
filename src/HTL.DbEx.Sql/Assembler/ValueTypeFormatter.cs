using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class ValueTypeFormatter : IValueTypeFormatter
    {
        public string Format(object value) => value.ToString();
    }
}
