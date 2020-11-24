using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<TimeSpan?>(NullableTimeSpanExpressionMediator a) => new SelectExpression<TimeSpan?>(a);
        public static implicit operator OrderByExpression(NullableTimeSpanExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableTimeSpanExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators 
        #region data type 
        #region byte



        #endregion

        #region decimal



        #endregion

        #region DateTime



        #endregion

        #region DateTimeOffset



        #endregion

        #region double



        #endregion

        #region float



        #endregion

        #region short



        #endregion

        #region int



        #endregion

        #region long



        #endregion

        #region string


        #endregion

        #region TimeSpan



        #endregion

        #endregion

        #region fields
        #region byte

        #endregion

        #region decimal

        #endregion

        #region DateTime

        #endregion

        #region DateTimeOffset

        #endregion

        #region double

        #endregion

        #region float

        #endregion

        #region short

        #endregion

        #region int

        #endregion

        #region long

        #endregion

        #region string

        #endregion

        #region TimeSpan

        #endregion

        #endregion

        #region mediators
        #region byte

        #endregion

        #region decimal

        #endregion

        #region DateTime

        #endregion

        #region DateTimeOffset

        #endregion

        #region double

        #endregion

        #region float

        #endregion

        #region short

        #endregion

        #region int

        #endregion

        #region long

        #endregion

        #region string

        #endregion

        #region TimeSpan

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TimeSpan
        public static FilterExpressionSet operator ==(NullableTimeSpanExpressionMediator a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanExpressionMediator a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanExpressionMediator a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanExpressionMediator a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanExpressionMediator a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanExpressionMediator a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(TimeSpan a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(TimeSpan a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(TimeSpan a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableTimeSpanExpressionMediator a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanExpressionMediator a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanExpressionMediator a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanExpressionMediator a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanExpressionMediator a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanExpressionMediator a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan? a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan? a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan? a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(TimeSpan? a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(TimeSpan? a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(TimeSpan? a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableTimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableTimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(NullableTimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableTimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
