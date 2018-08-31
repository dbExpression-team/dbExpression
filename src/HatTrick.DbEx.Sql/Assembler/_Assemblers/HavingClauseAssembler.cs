using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class HavingClauseAssembler : IDbExpressionAssemblyPartAssembler<HavingExpression>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as HavingExpression, builder, overrides);

        public string AssemblePart(HavingExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return builder.AssemblePart(expressionPart.Expression, overrides);
        }
    }
}
