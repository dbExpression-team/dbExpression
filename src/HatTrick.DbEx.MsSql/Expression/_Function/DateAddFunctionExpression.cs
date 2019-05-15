using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DateAddFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression, DateTime>,
        IEquatable<DateAddFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; }
        public (Type, object) DatePart { get; private set; }
        public (Type, object) Number { get; private set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        internal DateAddFunctionExpression()
        {
        }

        public DateAddFunctionExpression(ISupportedForFunctionExpression<IDbDateFunctionExpression> expression, (Type, object) datePart, int number)
        {
            Expression = (expression.GetType(), expression);
            DatePart = datePart;
            Number = (typeof(int), number);
        }
        #endregion

        #region as
        public DateAddFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"DateAdd({Expression})";
        #endregion

        #region equals
        public bool Equals(DateAddFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            if (this.Expression == default && obj.Expression != default) return false;
            if (obj.Expression == default && this.Expression != default) return false;
            if (this.Expression.Item1 != obj.Expression.Item1) return false;
            if (this.Expression.Item2 != obj.Expression.Item2) return false;

            if (this.DatePart == default && obj.DatePart != default) return false;
            if (obj.DatePart == default && this.DatePart != default) return false;
            if (this.DatePart.Item1 != obj.DatePart.Item1) return false;
            if (this.DatePart.Item2 != obj.DatePart.Item2) return false;

            if (this.Number != obj.Number) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DateAddFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(DateAddFunctionExpression a) => new SelectExpression(a);
        #endregion

        #region DateAdd to arithmetic operators
        public static ArithmeticExpression operator +(DateAddFunctionExpression a, DateAddFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(DateAddFunctionExpression a, DateAddFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);
        #endregion

        #region DateAdd to value relational operators
        public static FilterExpression operator ==(DateAddFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DateAddFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DateAddFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DateAddFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DateAddFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DateAddFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(DateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region DateAdd to DateAdd relational operators
        public static FilterExpression operator ==(DateAddFunctionExpression a, DateAddFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DateAddFunctionExpression a, DateAddFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DateAddFunctionExpression a, DateAddFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DateAddFunctionExpression a, DateAddFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DateAddFunctionExpression a, DateAddFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DateAddFunctionExpression a, DateAddFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
