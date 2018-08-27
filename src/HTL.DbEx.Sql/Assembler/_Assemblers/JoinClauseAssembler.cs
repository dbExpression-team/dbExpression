using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class JoinClauseAssembler : 
        ISqlPartAssembler<DBJoinExpressionSet>
    {
        public string Assemble(DBJoinExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Select(j => Assemble(j, builder, overrides)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBJoinExpressionSet, builder, overrides);

        public string Assemble(DBJoinExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            string expression = null;
            if (expressionPart.JoinType == DBExpressionJoinType.CROSS)
            {
                expression = $"CROSS JOIN {expressionPart.Entity}";
            }
            else
            {
                string entity = expressionPart.Entity.ToString("[s].[e]");
                string joinOn = builder.AssemblePart(expressionPart.Expression, overrides);
                expression = $"{expressionPart.JoinType} JOIN {entity} ON {joinOn}";
            }
            return expression;
        }
    }
}
