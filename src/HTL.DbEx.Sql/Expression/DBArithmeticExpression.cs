using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBArithmeticExpression : DBExpression, IDBExpressionSelectClausePart
    {
        #region interface
        public (Type, object) Expression { get; private set; }
        public (Type, object) LeftPart => ((DBExpressionPartPair)Expression.Item2).LeftPart;
        public (Type, object) RightPart => ((DBExpressionPartPair)Expression.Item2).RightPart;
        public DBArithmeticExpressionOperator ExpressionOperator { get; private set; }
        #endregion

        #region constructors
        internal DBArithmeticExpression(object leftArg, object rightArg, DBArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DBExpressionPartPair), new DBExpressionPartPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            //LeftPart = (leftArg.GetType(), leftArg);
            //RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = arithmeticOperator;
        }
        #endregion

        #region aggregate functions
        public DBSelectExpression Avg(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.AVG, distinct);

        public DBSelectExpression Min(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.MIN, distinct);

        public DBSelectExpression Max(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.MAX, distinct);

        public DBSelectExpression Sum(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.SUM, distinct);

        public DBSelectExpression Count(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.COUNT, distinct);
        #endregion

        #region to string
        public override string ToString() => $"({LeftPart.Item2} {ExpressionOperator} {RightPart.Item2})";
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
