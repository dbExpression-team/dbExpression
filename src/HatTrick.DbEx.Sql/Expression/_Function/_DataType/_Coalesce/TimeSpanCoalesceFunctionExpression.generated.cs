using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanCoalesceFunctionExpression
    {
        #region implicit operators
        public static implicit operator TimeSpanExpressionMediator(TimeSpanCoalesceFunctionExpression a) => new TimeSpanExpressionMediator(a);
        public static implicit operator OrderByExpression(TimeSpanCoalesceFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(TimeSpanCoalesceFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool



        #endregion
        
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
        
        #region Guid



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
        #region bool

        #endregion        
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
        #region Guid

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
        #region bool

        #endregion        
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
        #region Guid

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

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region TimeSpan
        public static FilterExpressionSet operator ==(TimeSpanCoalesceFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpanCoalesceFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpanCoalesceFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpanCoalesceFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpanCoalesceFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpanCoalesceFunctionExpression a, TimeSpan b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<TimeSpan>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpan a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpan a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpan a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<TimeSpan>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpanCoalesceFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpanCoalesceFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpanCoalesceFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpanCoalesceFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpanCoalesceFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpanCoalesceFunctionExpression a, TimeSpan? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TimeSpan?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpan? a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpan? a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpan? a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpan? a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpan? a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpan? a, TimeSpanCoalesceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TimeSpan?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(TimeSpanCoalesceFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpanCoalesceFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpanCoalesceFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpanCoalesceFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpanCoalesceFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpanCoalesceFunctionExpression a, TimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(TimeSpanCoalesceFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpanCoalesceFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpanCoalesceFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpanCoalesceFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpanCoalesceFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpanCoalesceFunctionExpression a, TimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpanCoalesceFunctionExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(TimeSpanCoalesceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TimeSpanCoalesceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(TimeSpanCoalesceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(TimeSpanCoalesceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(TimeSpanCoalesceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(TimeSpanCoalesceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
