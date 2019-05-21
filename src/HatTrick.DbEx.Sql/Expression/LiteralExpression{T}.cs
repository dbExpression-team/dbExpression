using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class LiteralExpression<TValue> : LiteralExpression,
        ISupportedForFunctionExpression<CastFunctionExpression, TValue>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, TValue>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TValue>,
        ISupportedForExpression<SelectExpression>
    {
        public LiteralExpression(TValue value) : base(value)
        {

        }

        #region literal to field relational operators
        public static FilterExpression operator ==(LiteralExpression<TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(LiteralExpression<TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(LiteralExpression<TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(LiteralExpression<TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(LiteralExpression<TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(LiteralExpression<TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region literal to field arithmetic operators
        public static ArithmeticExpression<TValue> operator +(LiteralExpression<TValue> a, FieldExpression b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<TValue> operator -(LiteralExpression<TValue> a, FieldExpression b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<TValue> operator *(LiteralExpression<TValue> a, FieldExpression b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<TValue> operator /(LiteralExpression<TValue> a, FieldExpression b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<TValue> operator %(LiteralExpression<TValue> a, FieldExpression b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Modulo);

        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
}
