using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class JoinClauseAssembler : 
        ISqlPartAssembler<DBJoinExpressionSet>
    {
        public string Assemble(DBJoinExpressionSet expressionPart, ISqlStatementBuilder builder)
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Select(j => Assemble(j, builder)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBJoinExpressionSet, builder);

        public string Assemble(DBJoinExpression expressionPart, ISqlStatementBuilder builder)
        {
            string expression = null;
            if (expressionPart.JoinType == DBExpressionJoinType.CROSS)
            {
                expression = $"CROSS JOIN {expressionPart.Entity}";
            }
            else
            {
                string entity = expressionPart.Entity.ToString("[s].[e]");
                string joinOn = builder.AssemblePart(expressionPart.Expression);
                expression = $"{expressionPart.JoinType} JOIN {entity} ON {joinOn}";
            }
            return expression;
        }
    }
}
