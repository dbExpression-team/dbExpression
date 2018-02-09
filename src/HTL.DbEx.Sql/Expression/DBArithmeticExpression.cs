using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBArithmeticExpression : DBExpression, IDBExpression
    {
        #region internals
        private readonly object _leftOperand;
        private readonly object _rightOperand;
        private readonly DBArithmeticExpressionOperator _arithmeticOperator;

        private string[] _operatorStrings = { " + ", " - ", " * ", " / ", " % " };
        #endregion

        #region interface
        #endregion

        #region constructors
        internal DBArithmeticExpression(object leftOperand, object rightOperand, DBArithmeticExpressionOperator arithmeticOperator)
        {
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
            _arithmeticOperator = arithmeticOperator;
        }
        #endregion

        #region aggregate functions
        public DBSelectExpression Avg(bool distinct = false) => new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.AVG, distinct);

        public DBSelectExpression Min(bool distinct = false) => new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.MIN, distinct);

        public DBSelectExpression Max(bool distinct = false) => new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.MAX, distinct);

        public DBSelectExpression Sum(bool distinct = false) => new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.SUM, distinct);

        public DBSelectExpression Count(bool distinct = false) => new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.COUNT, distinct);
        #endregion

        #region to string
        public override string ToString() => $"({this.FormatOperand(_leftOperand)}{_operatorStrings[(int)_arithmeticOperator]}{this.FormatOperand(_rightOperand)})";
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            string left = null;
            string right  = null;

            if (_leftOperand is string)
            {
                string paramName = "@AR" + (parameters.Count + 1);
                left = paramName;
                parameters.Add(dbService.GetDbParameter(paramName, _leftOperand, _leftOperand.GetType()));
            }
            else if (_leftOperand is IDBExpression)
            {
                left = (_leftOperand as IDBExpression).ToParameterizedString(parameters, dbService);
            }
            else if (_leftOperand is DBExpressionField)
            {
                left = _leftOperand.ToString();
            }
            else
            {
                left = _leftOperand.ToString();
            }


            if (_rightOperand is string)
            {
                string paramName = "@AR" + (parameters.Count + 1);
                right = paramName;
                parameters.Add(dbService.GetDbParameter(paramName, _rightOperand, _rightOperand.GetType()));
            }
            else if (_rightOperand is IDBExpression)
            {
                right = (_rightOperand as IDBExpression).ToParameterizedString(parameters, dbService);
            }
            else if ((_rightOperand is DBExpressionField))
            {
                right = _rightOperand.ToString();
            }
            else
            {
                right = _rightOperand.ToString();
            }

            expression = $"({left}{_operatorStrings[(int)_arithmeticOperator]}{right})";

            return expression;
        }
        #endregion

        #region format operand
        private string FormatOperand(object operand) => operand is string ? $"'{((string)operand).Replace("'", "''")}'" : operand.ToString();
        #endregion

        #region as
        public DBSelectExpression As(string alias) => new DBSelectExpression(this).As(alias);
        #endregion

        #region implicit select expression operator
        public static implicit operator DBSelectExpression(DBArithmeticExpression a) => new DBSelectExpression(a);
        #endregion

        #region implicit group by expression operator
        public static implicit operator DBGroupByExpression(DBArithmeticExpression a) => new DBGroupByExpression(a);
        #endregion

        #region arithmetic expression to value operators arithmetic operators
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, string b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator +(DBArithmeticExpression a, decimal b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator +(DBArithmeticExpression a, double b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator +(DBArithmeticExpression a, int b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator +(DBArithmeticExpression a, long b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, decimal b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, double b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, int b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, long b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, decimal b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, double b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, int b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, long b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, decimal b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, double b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, int b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, long b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, decimal b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, double b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, int b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, long b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        #endregion

        #region arithmetic expression to expression relational operators
        public static DBFilterExpression operator ==(DBArithmeticExpression a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator !=(DBArithmeticExpression a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator <(DBArithmeticExpression a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <=(DBArithmeticExpression a, DBExpression b)  => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator >(DBArithmeticExpression a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >=(DBArithmeticExpression a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region arithmetic to value relational operators
        public static DBFilterExpression operator ==(DBArithmeticExpression a, string b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBArithmeticExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBArithmeticExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBArithmeticExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBArithmeticExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator !=(DBArithmeticExpression a, string b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBArithmeticExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBArithmeticExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBArithmeticExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBArithmeticExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator <(DBArithmeticExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <(DBArithmeticExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <(DBArithmeticExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <(DBArithmeticExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <=(DBArithmeticExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator <=(DBArithmeticExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator <=(DBArithmeticExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator <=(DBArithmeticExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator >(DBArithmeticExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >(DBArithmeticExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >(DBArithmeticExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >(DBArithmeticExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >=(DBArithmeticExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);

        public static DBFilterExpression operator >=(DBArithmeticExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);

        public static DBFilterExpression operator >=(DBArithmeticExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);

        public static DBFilterExpression operator >=(DBArithmeticExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region arithmetic expression to arithmetic expression operators
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
    
}
