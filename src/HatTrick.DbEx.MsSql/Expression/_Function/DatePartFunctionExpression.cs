using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class DatePartFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int>,
        ISupportedForFunctionExpression<CastFunctionExpression, int>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int>,
        ISupportedForFunctionExpression<IDbNumericalFunctionExpression, int>,
        IEquatable<DatePartFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; }
        public DateParts DatePart { get; private set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        internal DatePartFunctionExpression()
        {
        }

        public DatePartFunctionExpression(ISupportedForFunctionExpression<IDbDateFunctionExpression> expression, DateParts datePart)
        {
            Expression = (expression.GetType(), expression);
            DatePart = datePart;
        }
        #endregion

        #region as
        public DatePartFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"DATEPART({Expression})";
        #endregion

        #region equals
        public bool Equals(DatePartFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.Expression == default && obj.Expression != default) return false;
            if (obj.Expression == default && this.Expression != default) return false;
            if (this.Expression.Item1 != obj.Expression.Item1) return false;
            if (this.Expression.Item2 != obj.Expression.Item2) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DatePartFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(DatePartFunctionExpression a) => new SelectExpression(a);
        #endregion

        #region DatePart to arithmetic operators
        public static ArithmeticExpression operator +(DatePartFunctionExpression a, DatePartFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(DatePartFunctionExpression a, DatePartFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(DatePartFunctionExpression a, DatePartFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(DatePartFunctionExpression a, DatePartFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(DatePartFunctionExpression a, DatePartFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region DatePart to value relational operators
        public static FilterExpression operator ==(DatePartFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DatePartFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DatePartFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DatePartFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DatePartFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DatePartFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region DatePart to DatePart relational operators
        public static FilterExpression operator ==(DatePartFunctionExpression a, DatePartFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DatePartFunctionExpression a, DatePartFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DatePartFunctionExpression a, DatePartFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DatePartFunctionExpression a, DatePartFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DatePartFunctionExpression a, DatePartFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DatePartFunctionExpression a, DatePartFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
