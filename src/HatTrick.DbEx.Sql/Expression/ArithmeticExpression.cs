using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression : DbExpression, IDbExpressionSelectClausePart, IAssemblyPart
    {
        #region interface
        public (Type, object) Expression { get; private set; }
        public (Type, object) LeftPart => ((DbExpressionPair)Expression.Item2).LeftPart;
        public (Type, object) RightPart => ((DbExpressionPair)Expression.Item2).RightPart;
        public ArithmeticExpressionOperator ExpressionOperator { get; private set; }
        #endregion

        #region constructors
        internal ArithmeticExpression(object leftArg, object rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }
        #endregion

        #region aggregate functions
        public SelectExpression Avg(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.AVG, distinct);

        public SelectExpression Min(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.MIN, distinct);

        public SelectExpression Max(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.MAX, distinct);

        public SelectExpression Sum(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.SUM, distinct);

        public SelectExpression Count(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.COUNT, distinct);
        #endregion

        #region to string
        public override string ToString() => $"({LeftPart.Item2} {ExpressionOperator} {RightPart.Item2})";
        #endregion

        #region as
        public SelectExpression As(string alias) => new SelectExpression(this).As(alias);
        #endregion

        #region implicit select expression operator
        public static implicit operator SelectExpression(ArithmeticExpression a) => new SelectExpression(a);
        #endregion

        #region implicit group by expression operator
        public static implicit operator GroupByExpression(ArithmeticExpression a) => new GroupByExpression(a);
        #endregion

        #region arithmetic expression to value operators arithmetic operators
        public static ArithmeticExpression operator +(ArithmeticExpression a, string b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator -(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator -(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator -(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator *(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator *(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator *(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator /(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator /(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator /(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression operator %(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression operator %(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression operator %(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region arithmetic expression to expression relational operators
        public static FilterExpression operator ==(ArithmeticExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression a, DbExpression b)  => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region arithmetic to value relational operators
        public static FilterExpression operator ==(ArithmeticExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region arithmetic expression to arithmetic expression operators
        public static ArithmeticExpression operator +(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
    
}
