using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IValueTypeFormatter
    {
        string Format(object value);
    }
}
