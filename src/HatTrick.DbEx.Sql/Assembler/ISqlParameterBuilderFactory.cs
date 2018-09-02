using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlParameterBuilderFactory
    {
        ISqlParameterBuilder CreateSqlParameterBuilder();
    }
}
