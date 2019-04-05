using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression : 
        IDbExpression, 
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectExpression
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; private set; }
        public (Type, object) LeftPart => ((DbExpressionPair)Expression.Item2).LeftPart;
        public (Type, object) RightPart => ((DbExpressionPair)Expression.Item2).RightPart;
        public ArithmeticExpressionOperator ExpressionOperator { get; private set; }

        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected ArithmeticExpression((Type, object) expression, ArithmeticExpressionOperator arithmeticOperator, string alias)
        {
            Expression = expression;
            ExpressionOperator = arithmeticOperator;
            Alias = alias;
        }

        protected ArithmeticExpression(object leftArg, object rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(ArithmeticExpression leftArg, IComparable rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(ArithmeticExpression), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(ArithmeticExpression leftArg, ArithmeticExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(ArithmeticExpression), leftArg), (typeof(ArithmeticExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(FieldExpression leftArg, ArithmeticExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(FieldExpression), leftArg), (typeof(ArithmeticExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(FieldExpression leftArg, IComparable rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(FieldExpression), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(FieldExpression leftArg, FieldExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(FieldExpression), leftArg), (typeof(FieldExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(CoalesceFunctionExpression leftArg, CoalesceFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(CoalesceFunctionExpression), leftArg), (typeof(CoalesceFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(IsNullFunctionExpression leftArg, IsNullFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(IsNullFunctionExpression), leftArg), (typeof(IsNullFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(IDbNumericalFunctionExpression leftArg, IComparable rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(IDbNumericalFunctionExpression leftArg, IDbNumericalFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (typeof(IsNullFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }
        #endregion

        #region to string
        public override string ToString() => $"({LeftPart.Item2} {ExpressionOperator} {RightPart.Item2})";
        #endregion

        #region as
        public ArithmeticExpression As(string alias) => new ArithmeticExpression(Expression, ExpressionOperator, alias);
        #endregion

        #region implicit select expression operator
        //public static implicit operator SelectExpression(ArithmeticExpression a) => new SelectExpression(a);
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
        public static FilterExpression operator ==(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression a, IDbExpression b)  => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
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
        //public static ArithmeticExpression operator +(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

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
