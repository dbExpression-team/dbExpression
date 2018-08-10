using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBSelectExpression : IDBExpressionSelectClausePart, IDBExpression, IAliasable
    {
        #region internals
        private string _alias;
        #endregion

        #region interface
        public (Type,object) Expression { get; }
        public bool IsDistinct { get; private set; }
        string IAliasable.Alias => _alias;
        #endregion

        #region constructors
        public DBSelectExpression(DBExpressionField field)
        {
            Expression = (typeof(DBExpressionField), field);
        }

        public DBSelectExpression(DBArithmeticExpression arithmeticExpression)
        {
            Expression = (typeof(DBArithmeticExpression), arithmeticExpression);
        }

        public DBSelectExpression(DBAggregateFunctionExpression aggregateFunctionExpression)
        {
            Expression = (typeof(DBAggregateFunctionExpression), aggregateFunctionExpression);
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Item2.ToString() + (string.IsNullOrWhiteSpace(_alias) ? string.Empty : (" AS " + _alias));
        #endregion

        #region as
        public virtual DBSelectExpression As(string alias)
        {
            this._alias = alias;
            return this;
        }
        #endregion

        #region select to select arithmetic operators
        public static DBArithmeticExpression operator +(DBSelectExpression a, DBSelectExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator -(DBSelectExpression a, DBSelectExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator *(DBSelectExpression a, DBSelectExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator /(DBSelectExpression a, DBSelectExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator %(DBSelectExpression a, DBSelectExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        #endregion

        #region select to value relational operators
        public static DBFilterExpression operator ==(DBSelectExpression a, string b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBSelectExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBSelectExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBSelectExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator ==(DBSelectExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator !=(DBSelectExpression a, string b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBSelectExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBSelectExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBSelectExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator !=(DBSelectExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator <(DBSelectExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <(DBSelectExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <(DBSelectExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <(DBSelectExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <=(DBSelectExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator <=(DBSelectExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator <=(DBSelectExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator <=(DBSelectExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator >(DBSelectExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >(DBSelectExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >(DBSelectExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >(DBSelectExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >=(DBSelectExpression a, decimal b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);

        public static DBFilterExpression operator >=(DBSelectExpression a, double b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);

        public static DBFilterExpression operator >=(DBSelectExpression a, int b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);

        public static DBFilterExpression operator >=(DBSelectExpression a, long b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region select to select relational operators
        public static DBFilterExpression operator ==(DBSelectExpression a, DBSelectExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator !=(DBSelectExpression a, DBSelectExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator <(DBSelectExpression a, DBSelectExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <=(DBSelectExpression a, DBSelectExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator >(DBSelectExpression a, DBSelectExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >=(DBSelectExpression a, DBSelectExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region logical & operator
        public static DBSelectExpressionSet operator &(DBSelectExpression a, DBSelectExpression b) => new DBSelectExpressionSet(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator DBSelectExpressionSet(DBSelectExpression a) => new DBSelectExpressionSet(a);
        #endregion

        #region implicit group by expression operator
        public static implicit operator DBGroupByExpression(DBSelectExpression a) => new DBGroupByExpression(a);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
}
