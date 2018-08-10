using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class SelectClauseAssembler : 
        ISqlPartAssembler<DBSelectExpressionSet>
    {
        public string Assemble(DBSelectExpressionSet expressionPart, ISqlStatementBuilder builder) 
            => expressionPart == null ? null : string.Join(", ", expressionPart.Expressions.Select(s => Assemble(s, builder)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBSelectExpressionSet, builder);

        public string Assemble(DBSelectExpression expressionPart, ISqlStatementBuilder builder)
        {
            if (expressionPart is null)
            {
                return null;
            }

            string expression = null;
            if (!typeof(IDBExpression).IsAssignableFrom(expressionPart.Expression.Item1))
            {
                expression = expressionPart.Expression.Item2.ToString();
            }
            else
            {
                expression = builder.AssemblePart(expressionPart.Expression);
            }
            var alias = (expressionPart as IAliasable)?.Alias;
            return !string.IsNullOrWhiteSpace(alias) ? $"{expression} AS {alias}" : expression;
        }
    }
}
