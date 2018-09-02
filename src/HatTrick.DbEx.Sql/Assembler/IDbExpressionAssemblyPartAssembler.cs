using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IDbExpressionAssemblyPartAssembler
    {
        string Assemble(object part, ISqlStatementBuilder builder, AssemblerOverrides overrides);
    }
}
