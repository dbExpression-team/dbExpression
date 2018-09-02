using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IValueTypeFormatter<T> : IValueTypeFormatter
        where T : IComparable
    {
        string Format(T value);
    }
}
