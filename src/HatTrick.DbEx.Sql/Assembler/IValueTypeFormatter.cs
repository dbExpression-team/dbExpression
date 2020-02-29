using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IValueTypeFormatter<TFrom, TTo> : IValueTypeFormatter
        where TFrom : IConvertible
        where TTo : IComparable
    {
        TTo Format(TFrom value);
    }
}
