using System;

namespace HTL.DbEx.Sql.Assembler
{
    public interface IValueTypeFormatter
    {
        string Format(object value);
    }
}
