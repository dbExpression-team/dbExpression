using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class HavingClauseAssembler : IDbExpressionAssemblyPartAssembler<HavingExpression>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as HavingExpression, builder, overrides);

        public string Assemble(HavingExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return builder.AssemblePart(expressionPart.Expression, overrides);
        }
    }
}
