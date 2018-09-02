using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Extensions.Attribute
{
    public static class AggregateFunctionAttributeExtensions
    {
        public static string GetAggregateFunction(this AggregateFunction value)
        {
            var values = Enum.GetValues(typeof(AggregateFunction));
            var fi = typeof(AggregateFunction).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.GetValue(i).Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                return ((ExpressionOperatorAttribute)attrs[0]).Operator;
            }

            return Enum.GetName(typeof(AggregateFunction), value);
        }
        
        public static AggregateFunction GetAggregateFunction(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return default(AggregateFunction);

            var values = Enum.GetValues(typeof(AggregateFunction));
            var fi = typeof(AggregateFunction).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return (AggregateFunction)values.GetValue(i);
            }

            if (Enum.TryParse(value, true, out AggregateFunction parsedValue))
                return parsedValue;

            return default(AggregateFunction);
        }

        public static SortedDictionary<AggregateFunction, string> GetValuesAndAggregateFunctions(this Type type)
        {
            if (type != typeof(AggregateFunction))
                throw new InvalidOperationException("Type must be DBSelectExpressionAggregateFunction");

            var sortedDictionary = new SortedDictionary<AggregateFunction, string>();
            foreach (var value in Enum.GetValues(type))
                sortedDictionary.Add((AggregateFunction)value, GetAggregateFunction((AggregateFunction)value));
            return sortedDictionary;
        }
    }
}
