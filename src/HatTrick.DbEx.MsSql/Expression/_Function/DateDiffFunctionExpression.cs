using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class DateDiffFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int>,
        ISupportedForFunctionExpression<CastFunctionExpression, int>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression, int>,
        IEquatable<DateDiffFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public DateParts DatePart { get; private set; }
        public (Type, object) StartDate { get; private set; }
        public (Type, object) EndDate { get; private set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        internal DateDiffFunctionExpression()
        {
        }

        public DateDiffFunctionExpression(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression> startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression> endDate)
        {
            DatePart = datePart;
            StartDate = (startDate.GetType(), startDate);
            EndDate = (endDate.GetType(), endDate);
        }

        public DateDiffFunctionExpression(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression> startDate, DateTime endDate)
        {
            DatePart = datePart;
            StartDate = (startDate.GetType(), startDate);
            EndDate = (typeof(DateTime), endDate);
        }

        public DateDiffFunctionExpression(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression> startDate, DateTimeOffset endDate)
        {
            DatePart = datePart;
            StartDate = (startDate.GetType(), startDate);
            EndDate = (typeof(DateTimeOffset), endDate);
        }

        public DateDiffFunctionExpression(DateParts datePart, DateTime startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression> endDate)
        {
            DatePart = datePart;
            StartDate = (typeof(DateTime), startDate);
            EndDate = (endDate.GetType(), endDate);
        }

        public DateDiffFunctionExpression(DateParts datePart, DateTimeOffset startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression> endDate)
        {
            DatePart = datePart;
            StartDate = (typeof(DateTimeOffset), startDate);
            EndDate = (endDate.GetType(), endDate);
        }
        #endregion

        #region as
        public DateDiffFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"DATEDIFF({DatePart.ToString().ToLower()}, {StartDate.Item2}, {EndDate.Item2})";
        #endregion

        #region equals
        public bool Equals(DateDiffFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            if (this.StartDate == default && obj.StartDate != default) return false;
            if (obj.StartDate == default && this.StartDate != default) return false;
            if (this.StartDate.Item1 != obj.StartDate.Item1) return false;
            if (this.StartDate.Item2 != obj.StartDate.Item2) return false;

            if (this.EndDate == default && obj.EndDate != default) return false;
            if (obj.EndDate == default && this.EndDate != default) return false;
            if (this.EndDate.Item1 != obj.EndDate.Item1) return false;
            if (this.EndDate.Item2 != obj.EndDate.Item2) return false;

            if (this.DatePart != obj.DatePart) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DateDiffFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(DateDiffFunctionExpression a) => new SelectExpression(a);
        public static implicit operator GroupByExpression(DateDiffFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region DateDiff to arithmetic operators
        public static ArithmeticExpression operator +(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region DateDiff to value relational operators
        public static FilterExpression operator ==(DateDiffFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DateDiffFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DateDiffFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DateDiffFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DateDiffFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DateDiffFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(DateDiffFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DateDiffFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DateDiffFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DateDiffFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DateDiffFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DateDiffFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region DateDiff to DateDiff relational operators
        public static FilterExpression operator ==(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(DateDiffFunctionExpression a, DateDiffFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
