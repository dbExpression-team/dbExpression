using System;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class GetDateFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeExpressionMediator(GetDateFunctionExpression a) => new DateTimeExpressionMediator(a);
        public static implicit operator OrderByExpression(GetDateFunctionExpression a) => new OrderByExpression(new DateTimeExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(GetDateFunctionExpression a) => new GroupByExpression(new DateTimeExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTime
        public static DateTimeExpressionMediator operator +(GetDateFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));

        public static DateTimeExpressionMediator operator +(DateTime a, GetDateFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));

        public static DateTimeExpressionMediator operator +(GetDateFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));

        public static DateTimeExpressionMediator operator +(DateTime? a, GetDateFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion
        
        #endregion

        #region mediator
        #region DateTime
        public static DateTimeExpressionMediator operator +(GetDateFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));

        public static NullableDateTimeExpressionMediator operator +(GetDateFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpressionSet operator ==(GetDateFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GetDateFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GetDateFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GetDateFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GetDateFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GetDateFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTime a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTime a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTime a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(GetDateFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GetDateFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GetDateFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GetDateFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GetDateFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GetDateFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime? a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime? a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime? a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTime? a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTime? a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTime? a, GetDateFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(GetDateFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GetDateFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GetDateFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GetDateFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GetDateFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GetDateFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(GetDateFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GetDateFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GetDateFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GetDateFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GetDateFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GetDateFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
