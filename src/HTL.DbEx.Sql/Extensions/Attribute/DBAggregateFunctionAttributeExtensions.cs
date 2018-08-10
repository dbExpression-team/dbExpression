using HTL.DbEx.Sql.Attribute;
using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Extensions.Attribute
{
    public static class DBAggregateFunctionAttributeExtensions
    {
        public static string GetAggregateFunction(this DBAggregateFunction value)
        {
            var values = Enum.GetValues(typeof(DBAggregateFunction));
            var fi = typeof(DBAggregateFunction).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.GetValue(i).Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                return ((ExpressionOperatorAttribute)attrs[0]).Operator;
            }

            return Enum.GetName(typeof(DBAggregateFunction), value);
        }
        
        public static DBAggregateFunction GetAggregateFunction(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return default(DBAggregateFunction);

            var values = Enum.GetValues(typeof(DBAggregateFunction));
            var fi = typeof(DBAggregateFunction).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return (DBAggregateFunction)values.GetValue(i);
            }

            if (Enum.TryParse(value, true, out DBAggregateFunction parsedValue))
                return parsedValue;

            return default(DBAggregateFunction);
        }

        public static SortedDictionary<DBAggregateFunction, string> GetValuesAndAggregateFunctions(this Type type)
        {
            if (type != typeof(DBAggregateFunction))
                throw new InvalidOperationException("Type must be DBSelectExpressionAggregateFunction");

            var sortedDictionary = new SortedDictionary<DBAggregateFunction, string>();
            foreach (var value in Enum.GetValues(type))
                sortedDictionary.Add((DBAggregateFunction)value, GetAggregateFunction((DBAggregateFunction)value));
            return sortedDictionary;
        }
    }
}
