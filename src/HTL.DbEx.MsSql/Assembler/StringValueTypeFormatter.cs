using HTL.DbEx.Sql.Assembler;
using System;

namespace HTL.DbEx.MsSql.Assembler
{
    public class StringValueTypeFormatter : IValueTypeFormatter<string>
    {
        public string Format(object value) => Format(value as string);
        public string Format(string value) => value.Replace("'", "''");
    }
}
