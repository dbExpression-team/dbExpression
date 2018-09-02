using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class OrderByClauseAssembler :
        IDbExpressionAssemblyPartAssembler<OrderByExpressionSet>
    {
        public string Assemble(OrderByExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(o => !(o is null)).Select(o => Assemble(o, builder, overrides)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as OrderByExpressionSet, builder, overrides);

        public string Assemble(OrderByExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return $"{builder.AssemblePart(expressionPart.Expression, overrides)} {expressionPart.Direction}";
        }
    }
}
