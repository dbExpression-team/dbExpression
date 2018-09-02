using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    /// <summary>
    /// Assembles a select query expecting more than 1 result
    /// </summary>
    public class SelectAllSqlStatementAssembler : SelectSqlStatementAssembler
    {
        protected override string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, string select, string distinct, string fromEntity, string where, string joins, string groupBy, string having, string orderBys)
        {
            throw new NotImplementedException("Assembly requires database platform specific implementations");
        }
    }
}
