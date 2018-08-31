using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByClauseAssembler : 
        IDbExpressionAssemblyPartAssembler<GroupByExpressionSet>,
        IDbExpressionAssemblyPartAssembler<GroupByExpression>
    {
        public string AssemblePart(GroupByExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(g => !(g is null)).Select(g => AssemblePart(g, builder, overrides)));

        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as GroupByExpressionSet, builder, overrides);

        public string AssemblePart(GroupByExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }

            return builder.AssemblePart(expressionPart.Expression, overrides);
        }
    }
}
