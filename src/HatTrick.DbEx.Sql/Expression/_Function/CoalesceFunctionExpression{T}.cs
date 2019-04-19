using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class CoalesceFunctionExpression<TValue> : CoalesceFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForFunctionExpression<CastFunctionExpression, TValue>,
        ISupportedForSelectFieldExpression<TValue>,
        IEquatable<CoalesceFunctionExpression<TValue>>
    {
        #region constructors
        internal CoalesceFunctionExpression()
        {
        }

        public CoalesceFunctionExpression(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue>> expressions)
        {
            Expressions = expressions.Select(e => (e.GetType(), (object)e)).ToList();
        }
        #endregion

        #region as
        public new CoalesceFunctionExpression<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(CoalesceFunctionExpression<TValue> obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            if (!this.Expressions.CompareTo(obj.Expressions))
                return false;

            if (this.Alias != obj.Alias) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is CoalesceFunctionExpression<TValue> exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region coalesce to arithmetic operators
        public static ArithmeticExpression operator +(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region coalese to value relational operators
        public static FilterExpression operator ==(CoalesceFunctionExpression<TValue> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(CoalesceFunctionExpression<TValue> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(CoalesceFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CoalesceFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CoalesceFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CoalesceFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(CoalesceFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CoalesceFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CoalesceFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CoalesceFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(CoalesceFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CoalesceFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CoalesceFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CoalesceFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(CoalesceFunctionExpression<TValue> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CoalesceFunctionExpression<TValue> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CoalesceFunctionExpression<TValue> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CoalesceFunctionExpression<TValue> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region coalesce to coalesce relational operators
        public static FilterExpression operator ==(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(CoalesceFunctionExpression<TValue> a, CoalesceFunctionExpression<TValue> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
