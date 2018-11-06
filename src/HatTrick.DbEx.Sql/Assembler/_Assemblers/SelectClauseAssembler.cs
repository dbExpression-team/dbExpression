using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectClauseAssembler : 
        IDbExpressionAssemblyPartAssembler<SelectExpressionSet>,
        IDbExpressionAssemblyPartAssembler<SelectExpression>
    {
        public string AssemblePart(SelectExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? null : string.Join(", ", expressionPart.Expressions.Select(s => AssemblePart(s, builder, overrides)));

        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => expressionPart is SelectExpression ?
                AssemblePart(expressionPart as SelectExpression, builder, overrides)
                : AssemblePart(expressionPart as SelectExpressionSet, builder, overrides);

        public string AssemblePart(SelectExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
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
