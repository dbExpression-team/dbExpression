using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class CurrentTimestampFunctionExpression : DataTypeFunctionExpression,
        IDbDateFunctionExpression,
        IAssemblyPart,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression, DateTime>,
        IEquatable<CurrentTimestampFunctionExpression>
    {
        #region as
        public new CurrentTimestampFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "CURRENT_TIMESTAMP";
        #endregion

        #region equals
        public bool Equals(CurrentTimestampFunctionExpression obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
         => obj is CurrentTimestampFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator DataTypeFunctionExpression<DateTime>(CurrentTimestampFunctionExpression timestamp) => new DataTypeFunctionExpression<DateTime>((timestamp.GetType(), timestamp));
        public static implicit operator OrderByExpression(CurrentTimestampFunctionExpression timestamp) => new OrderByExpression((timestamp.GetType(), timestamp), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(CurrentTimestampFunctionExpression timestamp) => new GroupByExpression((timestamp.GetType(), timestamp));
        #endregion

        #region CurrentTimestamp to arithmetic operators
        public static ArithmeticExpression operator +(CurrentTimestampFunctionExpression a, CurrentTimestampFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(CurrentTimestampFunctionExpression a, CurrentTimestampFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<DateTime> operator ==(CurrentTimestampFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(CurrentTimestampFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(CurrentTimestampFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(CurrentTimestampFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(CurrentTimestampFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(CurrentTimestampFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(CurrentTimestampFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(CurrentTimestampFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(CurrentTimestampFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(CurrentTimestampFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(CurrentTimestampFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(CurrentTimestampFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion

        #region filter operators
        #region datatype
        public static FilterExpression<DateTime> operator ==(CurrentTimestampFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(CurrentTimestampFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(CurrentTimestampFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(CurrentTimestampFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(CurrentTimestampFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(CurrentTimestampFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
