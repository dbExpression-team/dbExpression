using System;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysUtcDateTimeFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeExpressionMediator(SysUtcDateTimeFunctionExpression a) => new DateTimeExpressionMediator(a);
        public static implicit operator OrderByExpression(SysUtcDateTimeFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(SysUtcDateTimeFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SysUtcDateTimeFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, SysUtcDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, SysUtcDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SysUtcDateTimeFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime? a, SysUtcDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime? a, SysUtcDateTimeFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region mediators
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region DateTime
        public static FilterExpressionSet operator ==(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTime a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysUtcDateTimeFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTime? a, SysUtcDateTimeFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysUtcDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysUtcDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SysUtcDateTimeFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
