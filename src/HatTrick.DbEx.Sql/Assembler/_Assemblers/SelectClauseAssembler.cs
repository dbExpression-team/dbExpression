using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectClauseAssembler : 
        IDbExpressionAssemblyPartAssembler<SelectExpressionSet>
    {
        public string Assemble(SelectExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? null : string.Join(", ", expressionPart.Expressions.Select(s => Assemble(s, builder, overrides)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as SelectExpressionSet, builder, overrides);

        public string Assemble(SelectExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }

            string expression = null;
            if (!typeof(IDbExpression).IsAssignableFrom(expressionPart.Expression.Item1))
            {
                expression = expressionPart.Expression.Item2.ToString();
            }
            else
            {
                expression = builder.AssemblePart(expressionPart.Expression, overrides);
            }
            var alias = (expressionPart as IAliasable)?.Alias;
            return !string.IsNullOrWhiteSpace(alias) ? $"{expression} AS {alias}" : expression;
        }
    }
}
