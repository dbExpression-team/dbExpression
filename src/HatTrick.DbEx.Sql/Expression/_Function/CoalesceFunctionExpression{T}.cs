using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class CoalesceFunctionExpression<T> : CoalesceFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        IEquatable<CoalesceFunctionExpression<T>>
    {
        #region constructors
        internal CoalesceFunctionExpression()
        {
        }

        public CoalesceFunctionExpression(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, T>> expressions)
        {
            Expressions = expressions.Select(e => (e.GetType(), (object)e)).ToList();
        }
        #endregion

        #region as
        public new CoalesceFunctionExpression<T> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(CoalesceFunctionExpression<T> obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            if (!this.Expressions.CompareTo(obj.Expressions))
                return false;

            if (this.Alias != obj.Alias) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is CoalesceFunctionExpression<T> exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(CoalesceFunctionExpression<T> a) => new SelectExpression(a);
        #endregion

        #region isnull to arithmetic operators
        public static ArithmeticExpression operator +(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region isnull to value relational operators
        public static FilterExpression operator ==(CoalesceFunctionExpression<T> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(CoalesceFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(CoalesceFunctionExpression<T> a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(CoalesceFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(CoalesceFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CoalesceFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CoalesceFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(CoalesceFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(CoalesceFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CoalesceFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CoalesceFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(CoalesceFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(CoalesceFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CoalesceFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CoalesceFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(CoalesceFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(CoalesceFunctionExpression<T> a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CoalesceFunctionExpression<T> a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CoalesceFunctionExpression<T> a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(CoalesceFunctionExpression<T> a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region isnull to isnull relational operators
        public static FilterExpression operator ==(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(CoalesceFunctionExpression<T> a, CoalesceFunctionExpression<T> b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
