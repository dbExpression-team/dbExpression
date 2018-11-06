using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class WhereClauseAssembler :
        IDbExpressionAssemblyPartAssembler<FilterExpressionSet>,
        IDbExpressionAssemblyPartAssembler<FilterExpression>
    {
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<ConditionalExpressionOperator, string> _conditionalOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators());
        private static IDictionary<ConditionalExpressionOperator, string> ConditionalOperatorMap => _conditionalOperatorMap ?? (_conditionalOperatorMap = typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators());
        private static Func<bool, string, string> negate = (bool negate, string s) => negate ? $" NOT ({s})" : s;

        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is FilterExpressionSet set)
                return AssemblePart(set, builder, overrides);
            return AssemblePart((FilterExpression)expressionPart, builder, overrides);
        }

        public string AssemblePart(FilterExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (ReferenceEquals(expressionPart, null))
            {
                return null;
            }

            string left = string.Empty;
            if (expressionPart.LeftPart != default)
            {
                left = builder.AssemblePart(expressionPart.LeftPart, overrides);
            }
            string right = null;
            if (expressionPart.RightPart != default)
            {
                right = builder.AssemblePart(expressionPart.RightPart, overrides);
            }

            return negate
                (expressionPart.Negate, 
                right != null 
                    ? $"({left}{ConditionalOperatorMap[expressionPart.ConditionalOperator]}{right})"
                    : left
            );
        }

        public string AssemblePart(FilterExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }

            string left = builder.AssemblePart(expressionPart.LeftPart, overrides);
            if (expressionPart.RightPart != default)
            {
                if (expressionPart.ExpressionOperator == FilterExpressionOperator.In)
                {
                    var inParts = builder.AssemblePart(expressionPart.RightPart, overrides);
                    if (!string.IsNullOrWhiteSpace(inParts))
                        return negate(expressionPart.Negate, $"{left}{FilterOperatorMap[expressionPart.ExpressionOperator]}({inParts})");
                    return $"{left} IS NULL"; //TODO: is this right? if the "in" list is empty is it a null comparison?
                }

                string right = builder.AssemblePart(expressionPart.RightPart, overrides);

                //string right = typeof(IComparable).IsAssignableFrom(expressionPart.RightPart.Item1) ?
                //    builder.Parameters.Add(builder.FormatValueType(expressionPart.RightPart), expressionPart.RightPart.Item1).ParameterName
                //    :
                //    builder.AssemblePart(expressionPart.RightPart, overrides);

                if (!string.IsNullOrWhiteSpace(right))
                    return negate(expressionPart.Negate, $"{left}{FilterOperatorMap[expressionPart.ExpressionOperator]}{right}");

            }
            switch (expressionPart.ExpressionOperator)
            {
                case FilterExpressionOperator.Equal: return $"{left} IS NULL";
                case FilterExpressionOperator.NotEqual: return $"{left} IS NOT NULL";
                default:
                    throw new ArgumentException($"Operator {expressionPart.ExpressionOperator} invalid with null arguments");
            }
        }
    }
}
