using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlParameterBuilder
    {
        IList<DbParameter> Parameters { get; }
        DbParameter Add(object value);
        DbParameter Add(object value, Type valueType);
        DbParameter Add(object value, Type valueType, int? size);
    }
}
