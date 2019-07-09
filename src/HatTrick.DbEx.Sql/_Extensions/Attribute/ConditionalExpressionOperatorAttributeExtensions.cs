using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Attribute
{
    public static class ConditionalExpressionOperatorAttributeExtensions
    {
        public static string GetConditionalOperator(this ConditionalExpressionOperator value)
        {
            var values = Enum.GetValues(typeof(ConditionalExpressionOperator));
            var fi = typeof(ConditionalExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.GetValue(i).Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                return ((ExpressionOperatorAttribute)attrs[0]).Operator;
            }

            return Enum.GetName(typeof(ConditionalExpressionOperator), value);
        }

        public static ConditionalExpressionOperator GetConditionalOperator(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return default(ConditionalExpressionOperator);

            var values = Enum.GetValues(typeof(ConditionalExpressionOperator));
            var fi = typeof(ConditionalExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return (ConditionalExpressionOperator)values.GetValue(i);
            }

            if (Enum.TryParse(value, true, out ConditionalExpressionOperator parsedValue))
                return parsedValue;

            return default(ConditionalExpressionOperator);
        }

        public static SortedDictionary<ConditionalExpressionOperator, string> GetValuesAndConditionalOperators(this Type type)
        {
            if (type != typeof(ConditionalExpressionOperator))
                throw new InvalidOperationException("Type must be DBConditionalExpressionOperator");

            var sortedDictionary = new SortedDictionary<ConditionalExpressionOperator, string>();
            foreach (var value in Enum.GetValues(type))
                sortedDictionary.Add((ConditionalExpressionOperator)value, GetConditionalOperator((ConditionalExpressionOperator)value));
            return sortedDictionary;
        }
    }
}