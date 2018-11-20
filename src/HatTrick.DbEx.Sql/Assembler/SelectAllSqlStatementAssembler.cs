using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    /// <summary>
    /// Assembles a select query expecting more than 1 result
    /// </summary>
    public class SelectAllSqlStatementAssembler : SelectSqlStatementAssembler
    {
        public override void AppendPart(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            throw new NotImplementedException("Assembly requires database platform specific implementations");
        }
    }
}
