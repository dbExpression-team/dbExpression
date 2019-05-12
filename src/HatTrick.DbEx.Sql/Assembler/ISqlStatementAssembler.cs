using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementAssembler
    {
        void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context);
    }
}
