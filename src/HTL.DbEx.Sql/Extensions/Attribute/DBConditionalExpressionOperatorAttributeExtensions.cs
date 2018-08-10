using HTL.DbEx.Sql.Attribute;
using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

public static class DBConditionalExpressionOperatorAttributeExtensions
{
    public static string GetConditionalOperator(this DBConditionalExpressionOperator value)
    {
        var values = Enum.GetValues(typeof(DBConditionalExpressionOperator));
        var fi = typeof(DBConditionalExpressionOperator).GetFields();

        for (int i = 0; i < values.Length; i++)
        {
            if (!values.GetValue(i).Equals(value))
                continue;

            var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
            if (attrs == null || attrs.Length == 0)
                continue;

            return ((ExpressionOperatorAttribute)attrs[0]).Operator;
        }

        return Enum.GetName(typeof(DBConditionalExpressionOperator), value);
    }

    public static DBConditionalExpressionOperator GetConditionalOperator(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return default(DBConditionalExpressionOperator);

        var values = Enum.GetValues(typeof(DBConditionalExpressionOperator));
        var fi = typeof(DBConditionalExpressionOperator).GetFields();

        for (int i = 0; i < values.Length; i++)
        {
            var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
            if (attrs == null || attrs.Length == 0)
                continue;

            if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                return (DBConditionalExpressionOperator)values.GetValue(i);
        }

        if (Enum.TryParse(value, true, out DBConditionalExpressionOperator parsedValue))
            return parsedValue;

        return default(DBConditionalExpressionOperator);
    }

    public static SortedDictionary<DBConditionalExpressionOperator, string> GetValuesAndConditionalOperators(this Type type)
    {
        if (type != typeof(DBConditionalExpressionOperator))
            throw new InvalidOperationException("Type must be DBConditionalExpressionOperator");

        var sortedDictionary = new SortedDictionary<DBConditionalExpressionOperator, string>();
        foreach (var value in Enum.GetValues(type))
            sortedDictionary.Add((DBConditionalExpressionOperator)value, GetConditionalOperator((DBConditionalExpressionOperator)value));
        return sortedDictionary;
    }
}