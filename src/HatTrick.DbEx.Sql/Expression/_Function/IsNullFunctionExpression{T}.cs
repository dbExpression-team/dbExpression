using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class IsNullFunctionExpression<T> :
        IsNullFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionColumnExpression,
        IDbExpressionAliasProvider,
        IEquatable<IsNullFunctionExpression<T>>
        where T : IComparable
    {
        #region constructors
        internal IsNullFunctionExpression()
        {
        }

        public IsNullFunctionExpression(IDbExpressionColumnExpression<T> expression, T value)
            : base(expression, value)
        {
        }

        public IsNullFunctionExpression(IDbExpressionColumnExpression<T> expression, IDbExpressionColumnExpression<T> value)
            : base(expression, value)
        {
        }
        #endregion

        #region as
        public new IsNullFunctionExpression<T> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"ISNULL({Expression}, {Value})";
        #endregion

        #region equals
        public bool Equals(IsNullFunctionExpression<T> obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.Expression == default && obj.Expression != default) return false;
            if (obj.Expression == default && this.Expression != default) return false;
            if (!obj.Value.Equals(this.Value)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is IsNullFunctionExpression<T> exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(IsNullFunctionExpression<T> a) => new SelectExpression(a);
        #endregion

        #region isnull to arithmetic operators
        public static ArithmeticExpression operator +(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region isnull to value relational operators
        public static FilterExpression operator ==(IsNullFunctionExpression<T> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(IsNullFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(IsNullFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(IsNullFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(IsNullFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(IsNullFunctionExpression<T> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(IsNullFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(IsNullFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(IsNullFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(IsNullFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(IsNullFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(IsNullFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(IsNullFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(IsNullFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(IsNullFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(IsNullFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(IsNullFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(IsNullFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(IsNullFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(IsNullFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(IsNullFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(IsNullFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(IsNullFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(IsNullFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(IsNullFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(IsNullFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region isnull to isnull relational operators
        public static FilterExpression operator ==(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(IsNullFunctionExpression<T> a, IsNullFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
