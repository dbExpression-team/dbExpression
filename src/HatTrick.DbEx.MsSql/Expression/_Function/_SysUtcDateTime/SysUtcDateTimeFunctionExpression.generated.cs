using System;
using HatTrick.DbEx.Sql.Expression;


namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysUtcDateTimeFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime>(SysUtcDateTimeFunctionExpression a) => new SelectExpression<DateTime>(new DateTimeExpressionMediator(a));
        public static implicit operator DateTimeExpressionMediator(SysUtcDateTimeFunctionExpression a) => new DateTimeExpressionMediator(a);
        public static implicit operator OrderByExpression(SysUtcDateTimeFunctionExpression a) => new OrderByExpression(new DateTimeExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(SysUtcDateTimeFunctionExpression a) => new GroupByExpression(new DateTimeExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));

        public static DateTimeExpressionMediator operator +(DateTime a, SysUtcDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));

        public static DateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));

        public static DateTimeExpressionMediator operator +(DateTime? a, SysUtcDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion

        #endregion

        #region mediator
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));

        public static NullableDateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<bool> operator ==(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
