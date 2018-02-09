using System;
using System.Collections.Generic;
using System.Data.Common;
namespace HTL.DbEx.Sql.Expression
{
    public class DBAssignmentExpression : DBExpression, IDBExpression
    {
        #region interface
        public readonly DBExpressionField _field;
        public readonly object _value;
        #endregion

        #region constructors
        internal DBAssignmentExpression(DBExpressionField field, object value)
        {
            _field = field;
            _value = value;
        }
        #endregion

        #region to string
        public override string ToString() => $"{_field} = {this.FormatArgument(_value)}";
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_value is IDBExpression)
            {
                expression = $"{_field} = {(_value as IDBExpression).ToParameterizedString(parameters, dbService)}";
            }
            else if (_value is DBExpressionField)
            {
                expression = $"{_field} = {_value}";
            }
            else
            {
                string paramName = "@A" + (parameters.Count + 1);
                expression = _field.ToString() + " = " + paramName;
                if (_value == null)
                {
                    parameters.Add(dbService.GetDbParameter(paramName, _value));
                }
                else
                {
                    parameters.Add(dbService.GetDbParameter(paramName, _value, _value.GetType(), _field.Size));
                }
            }
            return expression;
        }
        #endregion

        #region format argument
        private string FormatArgument(object argument)
        {
            if (argument is string)
            {
                return (argument == null) ? "NULL" : $"'{((string)argument).Replace("'", "''")}'";
            }
            if (argument is DateTime || argument is Guid)
            {
                return $"'{argument}'";
            }
            else if (argument != null)
            {
                return argument.ToString();
            }

            return "NULL";
        }
        #endregion

        #region logical & operator
        public static DBAssignmentExpressionSet operator &(DBAssignmentExpression a, DBAssignmentExpression b) => new DBAssignmentExpressionSet(a, b);
        #endregion

        #region implicit assignment expression set operator
        public static implicit operator DBAssignmentExpressionSet(DBAssignmentExpression a) => new DBAssignmentExpressionSet(a);
        #endregion
    }
    
}
