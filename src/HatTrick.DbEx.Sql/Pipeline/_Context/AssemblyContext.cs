using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AssemblyContext
    {
        public ISqlStatementBuilder StatementBuilder { get; private set; }

        public AssemblyContext(ISqlStatementBuilder builder)
        {
            StatementBuilder = builder;
        }
    }
}
