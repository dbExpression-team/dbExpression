using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class GroupByAssembler : 
        ISqlPartAssembler<DBGroupByExpressionSet>
    {
        public string Assemble(DBGroupByExpressionSet expressionPart, ISqlStatementBuilder builder) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(g => !(g is null)).Select(g => Assemble(g, builder)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBGroupByExpressionSet, builder);

        public string Assemble(DBGroupByExpression expressionPart, ISqlStatementBuilder builder)
        {
            if (expressionPart is null)
            {
                return null;
            }

            return builder.AssemblePart(expressionPart.Expression);
        }
    }
}
