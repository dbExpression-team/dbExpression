using HTL.DbEx.Sql.Attribute;
using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Extensions.Attribute
{
    public static class DBFilterExpressionOperatorAttributeExtensions
    {
        public static string GetFilterOperator(this DBFilterExpressionOperator value)
        {
            var values = Enum.GetValues(typeof(DBFilterExpressionOperator));
            var fi = typeof(DBFilterExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.GetValue(i).Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                return ((ExpressionOperatorAttribute)attrs[0]).Operator;
            }

            return Enum.GetName(typeof(DBFilterExpressionOperator), value);
        }
        
        public static DBFilterExpressionOperator GetFilterOperator(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return default(DBFilterExpressionOperator);

            var values = Enum.GetValues(typeof(DBFilterExpressionOperator));
            var fi = typeof(DBFilterExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return (DBFilterExpressionOperator)values.GetValue(i);
            }

            if (Enum.TryParse(value, true, out DBFilterExpressionOperator parsedValue))
                return parsedValue;

            return default(DBFilterExpressionOperator);
        }

        public static SortedDictionary<DBFilterExpressionOperator, string> GetValuesAndFilterOperators(this Type type)
        {
            if (type != typeof(DBFilterExpressionOperator))
                throw new InvalidOperationException("Type must be DBFilterExpressionOperator");

            var sortedDictionary = new SortedDictionary<DBFilterExpressionOperator, string>();
            foreach (var value in Enum.GetValues(type))
                sortedDictionary.Add((DBFilterExpressionOperator)value, GetFilterOperator((DBFilterExpressionOperator)value));
            return sortedDictionary;
        }
    }
}
