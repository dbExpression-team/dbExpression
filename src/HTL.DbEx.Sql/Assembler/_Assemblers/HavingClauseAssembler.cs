using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class HavingClauseAssembler : ISqlPartAssembler<DBHavingExpression>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBHavingExpression, builder, overrides);

        public string Assemble(DBHavingExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return builder.AssemblePart(expressionPart.Expression, overrides);
        }
    }
}
