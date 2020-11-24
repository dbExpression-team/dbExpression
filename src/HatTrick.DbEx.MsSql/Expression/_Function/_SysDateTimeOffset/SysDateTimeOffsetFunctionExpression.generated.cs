using System;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysDateTimeOffsetFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeOffsetExpressionMediator(SysDateTimeOffsetFunctionExpression a) => new DateTimeOffsetExpressionMediator(a);
        public static implicit operator OrderByExpression(SysDateTimeOffsetFunctionExpression a) => new OrderByExpression(new DateTimeOffsetExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(SysDateTimeOffsetFunctionExpression a) => new GroupByExpression(new DateTimeOffsetExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));

        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion
        
        #endregion

        #region mediator
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));

        public static NullableDateTimeOffsetExpressionMediator operator +(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffset a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffset? a, SysDateTimeOffsetFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(SysDateTimeOffsetFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
