using System;
using HatTrick.DbEx.Sql.Expression;


namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysDateTimeFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime>(SysDateTimeFunctionExpression a) => new SelectExpression<DateTime>(new ExpressionContainer(a));
        public static implicit operator DateTimeExpressionMediator(SysDateTimeFunctionExpression a) => new DateTimeExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(SysDateTimeFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(SysDateTimeFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));

        public static DateTimeExpressionMediator operator +(DateTime a, SysDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));

        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));

        public static DateTimeExpressionMediator operator +(DateTime? a, SysDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        #endregion

        #endregion

        #region mediator
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableDateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<DateTime> operator ==(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<DateTime> operator ==(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
