using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableTimeSpanExpressionMediator(NullableTimeSpanMaximumFunctionExpression a) => new NullableTimeSpanExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableTimeSpanMaximumFunctionExpression a) => new OrderByExpression(new TimeSpanExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new TimeSpanExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new TimeSpanExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte



        
        #endregion
        
        #region decimal



        
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
        
        #endregion

        #region mediator
        #region byte

        #endregion
        
        #region decimal

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
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region TimeSpan
        public static FilterExpressionSet operator ==(NullableTimeSpanMaximumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMaximumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMaximumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMaximumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanMaximumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanMaximumFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(TimeSpan a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(TimeSpan a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(TimeSpan a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableTimeSpanMaximumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMaximumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMaximumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMaximumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanMaximumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanMaximumFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan? a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan? a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan? a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(TimeSpan? a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(TimeSpan? a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(TimeSpan? a, NullableTimeSpanMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(NullableTimeSpanMaximumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMaximumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMaximumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMaximumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanMaximumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanMaximumFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableTimeSpanMaximumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableTimeSpanMaximumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableTimeSpanMaximumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableTimeSpanMaximumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableTimeSpanMaximumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableTimeSpanMaximumFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
