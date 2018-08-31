using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementAssembler
    {
        SqlStatement AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides);
    }
}
