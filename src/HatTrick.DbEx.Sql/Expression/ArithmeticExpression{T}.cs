using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression<T> :
        ArithmeticExpression,
        ISupportedForFunctionExpression<IsNullFunctionExpression, T>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, T>,
        ISupportedForExpression<SelectExpression>
    {
        #region constructors
        internal ArithmeticExpression(object leftArg, object rightArg, ArithmeticExpressionOperator arithmeticOperator)
            : base(leftArg, rightArg, arithmeticOperator)
        {
        }
        #endregion

        #region implicit select expression operator
        //public static implicit operator SelectExpression(ArithmeticExpression<T> a) => new SelectExpression(a);
        #endregion

        #region implicit group by expression operator
        public static implicit operator GroupByExpression(ArithmeticExpression<T> a) => new GroupByExpression(a);
        #endregion

        #region arithmetic expression to value operators arithmetic operators
        public static ArithmeticExpression<T> operator +(ArithmeticExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<T> operator -(ArithmeticExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<T> operator *(ArithmeticExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<T> operator /(ArithmeticExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<T> operator %(ArithmeticExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Modulo);

        #endregion

        #region arithmetic expression to expression relational operators
        public static FilterExpression operator ==(ArithmeticExpression<T> a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression<T> a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression<T> a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression<T> a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression<T> a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression<T> a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region arithmetic to value relational operators
        public static FilterExpression operator ==(ArithmeticExpression<T> a, T b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression<T> a, T b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression<T> a, T b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression<T> a, T b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression<T> a, T b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression<T> a, T b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region arithmetic expression to arithmetic expression operators
        public static ArithmeticExpression<T> operator +(ArithmeticExpression<T> a, ArithmeticExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<T> operator -(ArithmeticExpression<T> a, ArithmeticExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<T> operator *(ArithmeticExpression<T> a, ArithmeticExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<T> operator /(ArithmeticExpression<T> a, ArithmeticExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<T> operator %(ArithmeticExpression<T> a, ArithmeticExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }

}
