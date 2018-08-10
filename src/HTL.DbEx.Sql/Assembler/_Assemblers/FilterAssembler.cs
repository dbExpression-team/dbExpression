using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Assembler
{
    public class FilterAssembler :
        ISqlPartAssembler<DBFilterExpressionSet>
    {
        private static IDictionary<DBFilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<DBConditionalExpressionOperator, string> _conditionalOperatorMap;
        private static IDictionary<DBFilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(DBFilterExpressionOperator).GetValuesAndFilterOperators());
        private static IDictionary<DBConditionalExpressionOperator, string> ConditionalOperatorMap => _conditionalOperatorMap ?? (_conditionalOperatorMap = typeof(DBConditionalExpressionOperator).GetValuesAndConditionalOperators());
        private static Func<bool, string, string> negate = (bool negate, string s) => negate ? $" NOT ({s})" : s;

        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
        {
            return expressionPart is DBFilterExpressionSet ?
                Assemble((DBFilterExpressionSet)expressionPart, builder)
                :
                Assemble((DBFilterExpression)expressionPart, builder);
        }

        public string Assemble(DBFilterExpressionSet expressionPart, ISqlStatementBuilder builder)
        {
            if (ReferenceEquals(expressionPart, null))
            {
                return null;
            }

            string left = string.Empty;
            if (!expressionPart.LeftPart.Equals(default(ValueTuple<Type,object>)))
            {
                left = builder.AssemblePart(expressionPart.LeftPart);
            }
            string right = string.Empty;
            if (!expressionPart.RightPart.Equals(default(ValueTuple<Type, object>)))
            {
                right = builder.AssemblePart(expressionPart.RightPart);
            }

            return negate
                (expressionPart.Negate, 
                !string.IsNullOrWhiteSpace(left) 
                    ? $"({left}{ConditionalOperatorMap[expressionPart.ConditionalOperator]}{right})"
                    : right
            );
        }

        public string Assemble(DBFilterExpression expressionPart, ISqlStatementBuilder builder)
        {
            if (expressionPart is null)
            {
                return null;
            }

            string left = builder.AssemblePart(expressionPart.LeftPart);
            if (!expressionPart.RightPart.Equals(default(ValueTuple<Type, object>)))
            {
                if (expressionPart.ExpressionOperator == DBFilterExpressionOperator.In)
                {
                    var inParts = builder.AssemblePart(expressionPart.RightPart);
                    if (!string.IsNullOrWhiteSpace(inParts))
                        return negate(expressionPart.Negate, $"{left}{FilterOperatorMap[expressionPart.ExpressionOperator]}({inParts})");
                    return $"{left} IS NULL"; //TODO: is this right? if the "in" list is empty is it a null comparison?
                }

                string right = typeof(IComparable).IsAssignableFrom(expressionPart.RightPart.Item1) ? 
                    builder.Parameters.Add(builder.FormatValueType(expressionPart.RightPart), expressionPart.RightPart.Item1).ParameterName
                    :
                    builder.AssemblePart(expressionPart.RightPart);

                if (!string.IsNullOrWhiteSpace(right))
                    return negate(expressionPart.Negate, $"{left}{FilterOperatorMap[expressionPart.ExpressionOperator]}{right}");

            }
            switch (expressionPart.ExpressionOperator)
            {
                case DBFilterExpressionOperator.Equal: return $"{left} IS NULL";
                case DBFilterExpressionOperator.NotEqual: return $"{left} IS NOT NULL";
                default:
                    throw new ArgumentException($"Operator {expressionPart.ExpressionOperator} invalid with null arguments");
            }
        }
    }
}
