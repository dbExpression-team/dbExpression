using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public interface ISqlPartAssembler
    {
        string Assemble(object part, ISqlStatementBuilder builder);
    }
}
