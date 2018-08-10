using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class HavingClauseAssembler : ISqlPartAssembler<DBHavingExpression>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBHavingExpression, builder);

        public string Assemble(DBHavingExpression expressionPart, ISqlStatementBuilder builder)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return builder.AssemblePart(expressionPart.Expression);
        }
    }
}
