using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class GroupByAssembler : 
        ISqlPartAssembler<DBGroupByExpressionSet>
    {
        public string Assemble(DBGroupByExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(g => !(g is null)).Select(g => Assemble(g, builder, overrides)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBGroupByExpressionSet, builder, overrides);

        public string Assemble(DBGroupByExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }

            return builder.AssemblePart(expressionPart.Expression, overrides);
        }
    }
}
