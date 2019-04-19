using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class CastFunctionExpression<TValue> : CastFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, TValue>,
        ISupportedForSelectFieldExpression<TValue>,
        IEquatable<CastFunctionExpression<TValue>>
        where TValue : IComparable
    {
        #region constructors
        internal CastFunctionExpression()
        {
        }

        public CastFunctionExpression((Type,object) expression) : base(expression)
        {
        }

        public CastFunctionExpression(FieldExpression oldField) : base(oldField)
        {
        }

        public CastFunctionExpression(ISupportedForFunctionExpression<CastFunctionExpression> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new CastFunctionExpression<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(CastFunctionExpression<TValue> obj)
        {
            if (base.Equals(obj)) return false;

            if (this.Alias != obj.Alias) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is CastFunctionExpression<TValue> exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region cast to arithmetic operators
        public static ArithmeticExpression operator +(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region cast to value relational operators
        public static FilterExpression operator ==(CastFunctionExpression<TValue> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CastFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CastFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CastFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CastFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(CastFunctionExpression<TValue> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CastFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CastFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CastFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CastFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(CastFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CastFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CastFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CastFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(CastFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CastFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CastFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CastFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(CastFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CastFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CastFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CastFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(CastFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CastFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CastFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CastFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region cast to cast relational operators
        public static FilterExpression operator ==(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(CastFunctionExpression<TValue> a, CastFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
