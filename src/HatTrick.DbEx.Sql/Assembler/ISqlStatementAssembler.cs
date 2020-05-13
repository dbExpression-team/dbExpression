using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementAssembler
    {
        void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context);
    }

    public interface ISqlStatementAssembler<T> : ISqlStatementAssembler
        where T : AssemblyContext
    {
        void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, T context);
    }
}
