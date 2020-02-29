using System;
using HatTrick.DbEx.Sql.Expression;


namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysDateTimeOffsetFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTimeOffset>(SysDateTimeOffsetFunctionExpression a) => new SelectExpression<DateTimeOffset>(new ExpressionContainer(a));
        public static implicit operator DateTimeOffsetExpressionMediator(SysDateTimeOffsetFunctionExpression a) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(SysDateTimeOffsetFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(SysDateTimeOffsetFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));

        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        #endregion

        #endregion

        #region mediator
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableDateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<DateTimeOffset> operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset?> operator !=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset?> operator <(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset?> operator <=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset?> operator >(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset?> operator >=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
