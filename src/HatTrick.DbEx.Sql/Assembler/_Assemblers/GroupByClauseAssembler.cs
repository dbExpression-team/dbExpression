using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByAssembler : 
        IDbExpressionAssemblyPartAssembler<GroupByExpressionSet>
    {
        public string Assemble(GroupByExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(g => !(g is null)).Select(g => Assemble(g, builder, overrides)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as GroupByExpressionSet, builder, overrides);

        public string Assemble(GroupByExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }

            return builder.AssemblePart(expressionPart.Expression, overrides);
        }
    }
}
