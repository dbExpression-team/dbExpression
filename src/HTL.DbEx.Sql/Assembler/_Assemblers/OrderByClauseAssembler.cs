using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class OrderByClauseAssembler :
        ISqlPartAssembler<DBOrderByExpressionSet>
    {
        public string Assemble(DBOrderByExpressionSet expressionPart, ISqlStatementBuilder builder) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(o => !(o is null)).Select(o => Assemble(o, builder)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBOrderByExpressionSet, builder);

        public string Assemble(DBOrderByExpression expressionPart, ISqlStatementBuilder builder)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return $"{builder.AssemblePart(expressionPart.Expression)} {expressionPart.Direction}";
        }
    }
}
