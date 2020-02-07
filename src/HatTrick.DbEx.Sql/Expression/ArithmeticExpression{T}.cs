using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression<TValue> :
        ArithmeticExpression,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TValue>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue>,
        ISupportedForSelectFieldExpression<TValue>
    {
        #region constructors
        public ArithmeticExpression(IDbExpression leftArg, (Type, object) rightArg, ArithmeticExpressionOperator arithmeticOperator)
            : base(leftArg, rightArg, arithmeticOperator)
        {
        }

        public ArithmeticExpression(IDbExpression leftArg, IDbExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
            : base(leftArg, rightArg, arithmeticOperator)
        {
        }

        public ArithmeticExpression((Type, object) leftArg, IDbExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
            : base(leftArg, rightArg, arithmeticOperator)
        {
        }

        public ArithmeticExpression((Type,object) leftArg, (Type,object) rightArg, ArithmeticExpressionOperator arithmeticOperator)
            : base(leftArg, rightArg, arithmeticOperator)
        {
        }
        #endregion

        #region as
        public new ArithmeticExpression<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator ExpressionMediator<TValue>(ArithmeticExpression<TValue> math) => new ExpressionMediator<TValue>((math.GetType(), math));
        #endregion

        #region arithmetic operators
        #region operators
        public static ArithmeticExpression<TValue> operator +(ArithmeticExpression<TValue> a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<TValue> operator -(ArithmeticExpression<TValue> a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<TValue> operator *(ArithmeticExpression<TValue> a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<TValue> operator /(ArithmeticExpression<TValue> a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<TValue> operator %(ArithmeticExpression<TValue> a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region literal
        public static ArithmeticExpression<TValue> operator +(ArithmeticExpression<TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, new LiteralExpression<TValue>(b), ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<TValue> operator -(ArithmeticExpression<TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, new LiteralExpression<TValue>(b), ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<TValue> operator *(ArithmeticExpression<TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, new LiteralExpression<TValue>(b), ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<TValue> operator /(ArithmeticExpression<TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, new LiteralExpression<TValue>(b), ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<TValue> operator %(ArithmeticExpression<TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, new LiteralExpression<TValue>(b), ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression<TValue> operator +(TValue a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(new LiteralExpression<TValue>(a), b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<TValue> operator -(TValue a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(new LiteralExpression<TValue>(a), b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<TValue> operator *(TValue a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(new LiteralExpression<TValue>(a), b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<TValue> operator /(TValue a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(new LiteralExpression<TValue>(a), b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<TValue> operator %(TValue a, ArithmeticExpression<TValue> b) => new ArithmeticExpression<TValue>(new LiteralExpression<TValue>(a), b, ArithmeticExpressionOperator.Modulo);
        #endregion
        #endregion

        #region filter operators
        public static FilterExpression operator ==(ArithmeticExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(TValue a, ArithmeticExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a),  b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(TValue a, ArithmeticExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(TValue a, ArithmeticExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(TValue a, ArithmeticExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(TValue a, ArithmeticExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(TValue a, ArithmeticExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

    }

}
