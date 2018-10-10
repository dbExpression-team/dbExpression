using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBFilterExpression : DBExpression, IDBExpression
    {
        #region interface
        private readonly object _leftArg;
        private readonly object _rightArg;
        private readonly DBFilterExpressionOperator _expressionOperator;
        private bool Negate { get; set; }
        
        //TODO: JRod, remove this and cache some static based on enum attributes to avoid out of sync issues moving forward...
        private static string[] _operatorStrings = new string[] { " = ", " <> ", " < ", " <= ", " > ", " >= ", " LIKE ", " IN " };
        #endregion

        #region constructors
        internal DBFilterExpression(object leftArg, object rightArg, DBFilterExpressionOperator expressionOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _expressionOperator = expressionOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression = null;
            if (_rightArg != null)
            {
                expression = $"{this.FormatArgument(_leftArg)}{_operatorStrings[(int)_expressionOperator]}{this.FormatArgument(_rightArg)}";
            }
            else
            {
                switch (_expressionOperator)
                {
                    case DBFilterExpressionOperator.Equal:
                        expression = $"{this.FormatArgument(_leftArg)} IS NULL";
                        break;
                    case DBFilterExpressionOperator.NotEqual:
                        expression = $"{this.FormatArgument(_leftArg)} IS NOT NULL";
                        break;
                    default:
                        throw new ArgumentException($"Operator {_expressionOperator} invalid with null arguments");
                }
            }

            if (expression == null) { expression = "0=0"; }

            return (Negate) ? $" NOT ({expression})" : expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_rightArg != null)
            {
                if (_rightArg is DBExpression || _rightArg is DBExpressionField)
                {
                    expression = $"{this.FormatArgument(_leftArg)}{_operatorStrings[(int)_expressionOperator]}{this.FormatArgument(_rightArg)}";
                }
                else
                {
                    if (_expressionOperator == DBFilterExpressionOperator.In)
                    {
                        //TODO: JRod, consider making each item within the in array an individual parameter...
                        expression = $"{_leftArg} {_operatorStrings[(int)_expressionOperator]} {this.FormatArgument(_rightArg)}";
                    }
                    else
                    {
                        if (_rightArg == DBNull.Value)
                        {
                            expression = $"{this.FormatArgument(_leftArg)} IS NULL";
                        }
                        else
                        {
                            string paramName = $"@F{(parameters.Count + 1)}";
                            expression = $"{this.FormatArgument(_leftArg)}{_operatorStrings[(int)_expressionOperator]}{paramName}";
                            parameters.Add(dbService.GetDbParameter(paramName, _rightArg, _rightArg.GetType()));
                        }
                    }
                }
            }
            else
            {
                expression = this.ToString();
            }

            if (expression == null) { expression = "0=0"; }

            return (Negate) ? $" NOT ({expression})" : expression;
        }
        #endregion

        #region format argument
        private string FormatArgument(object argument) //TODO: JRod, optimize this...
        {
            if (argument is DBExpressionField)
            {
                return argument.ToString();
            }
            if (argument is DBExpression)
            {
                return argument.ToString();
            }
            if (argument is Enum)
            {
                return Convert.ToInt32(argument).ToString();
            }
            if (argument is DateTime || argument is Guid)
            {
                return $"'{argument}'";
            }
            if (argument is string)
            {
                return $"'{((string)argument).Replace("'", "''")}'";
            }
            else if (argument is Array)
            {
                if ((argument as Array).Length == 0)
                {
                    return "(NULL)";
                }
                var arguments = new List<string>();
                if ((argument is string[]) || (argument is DateTime[]) || (argument is Guid[]))
                {
                    foreach (object o in (Array)argument)
                    {
                        arguments.Add(FormatArgument((string)o));
                    }
                }
                else
                {
                    foreach (object o in (Array)argument)
                    {
                        arguments.Add(FormatArgument(o));
                    }
                }
                return $"({string.Join(",", arguments.ToArray())})";
            }
            else if (argument != null)
            {
                return argument.ToString();
            }

            return "NULL";
        }
        #endregion

        #region conditional &, | operators
        public static DBFilterExpressionSet operator &(DBFilterExpression a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return new DBFilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpression a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return new DBFilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator DBFilterExpressionSet(DBFilterExpression a) => new DBFilterExpressionSet(a);
        #endregion

        #region implicit having expression set operator
        public static implicit operator DBHavingExpression(DBFilterExpression a) => new DBHavingExpression(a);
        #endregion

        #region negation operator
        public static DBFilterExpression operator !(DBFilterExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
