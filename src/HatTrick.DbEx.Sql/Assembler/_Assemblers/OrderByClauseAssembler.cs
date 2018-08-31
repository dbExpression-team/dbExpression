using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class OrderByClauseAssembler :
        IDbExpressionAssemblyPartAssembler<OrderByExpressionSet>,
        IDbExpressionAssemblyPartAssembler<OrderByExpression>
    {
        public string AssemblePart(OrderByExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(o => !(o is null)).Select(o => AssemblePart(o, builder, overrides)));

        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as OrderByExpressionSet, builder, overrides);

        public string AssemblePart(OrderByExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return $"{builder.AssemblePart(expressionPart.Expression, overrides)} {expressionPart.Direction}";
        }
    }
}
