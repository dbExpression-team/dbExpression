using HTL.DbEx.Sql.Attribute;
using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Extensions.Attribute
{
    public static class DBArithmeticiExpressionOperatorAttributeExtensions
    {
        public static string GetArithmeticOperator(this DBArithmeticExpressionOperator value)
        {
            var values = Enum.GetValues(typeof(DBArithmeticExpressionOperator));
            var fi = typeof(DBArithmeticExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.GetValue(i).Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                return ((ExpressionOperatorAttribute)attrs[0]).Operator;
            }

            return Enum.GetName(typeof(DBArithmeticExpressionOperator), value);
        }
        
        public static DBArithmeticExpressionOperator GetArithmeticOperator(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return default(DBArithmeticExpressionOperator);

            var values = Enum.GetValues(typeof(DBArithmeticExpressionOperator));
            var fi = typeof(DBArithmeticExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;

                if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return (DBArithmeticExpressionOperator)values.GetValue(i);
            }

            if (Enum.TryParse(value, true, out DBArithmeticExpressionOperator parsedValue))
                return parsedValue;

            return default(DBArithmeticExpressionOperator);
        }

        public static SortedDictionary<DBArithmeticExpressionOperator, string> GetValuesAndArithmeticOperators(this Type type)
        {
            if (type != typeof(DBArithmeticExpressionOperator))
                throw new InvalidOperationException("Type must be DBArithmeticExpressionOperator");

            var sortedDictionary = new SortedDictionary<DBArithmeticExpressionOperator, string>();
            foreach (var value in Enum.GetValues(type))
                sortedDictionary.Add((DBArithmeticExpressionOperator)value, GetArithmeticOperator((DBArithmeticExpressionOperator)value));
            return sortedDictionary;
        }
    }
}
