using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IValueTypeFormatter
    {
        object Format(object value);
    }
}
