using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Attribute
{
    public static class FilterExpressionOperatorAttributeExtensions
    {
        public static string GetFilterOperator(this FilterExpressionOperator value)
        {
            var values = Enum.GetValues(typeof(FilterExpressionOperator));
            var fi = typeof(FilterExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.GetValue(i).Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                return ((ExpressionOperatorAttribute)attrs[0]).Operator;
            }

            return Enum.GetName(typeof(FilterExpressionOperator), value);
        }
        
        public static FilterExpressionOperator GetFilterOperator(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return default(FilterExpressionOperator);

            var values = Enum.GetValues(typeof(FilterExpressionOperator));
            var fi = typeof(FilterExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return (FilterExpressionOperator)values.GetValue(i);
            }

            if (Enum.TryParse(value, true, out FilterExpressionOperator parsedValue))
                return parsedValue;

            return default(FilterExpressionOperator);
        }

        public static SortedDictionary<FilterExpressionOperator, string> GetValuesAndFilterOperators(this Type type)
        {
            if (type != typeof(FilterExpressionOperator))
                throw new InvalidOperationException("Type must be DBFilterExpressionOperator");

            var sortedDictionary = new SortedDictionary<FilterExpressionOperator, string>();
            foreach (var value in Enum.GetValues(type))
                sortedDictionary.Add((FilterExpressionOperator)value, GetFilterOperator((FilterExpressionOperator)value));
            return sortedDictionary;
        }
    }
}
