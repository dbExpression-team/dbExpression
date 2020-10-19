using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<TimeSpan>(TimeSpanExpressionMediator a) => new SelectExpression<TimeSpan>(a);
        public static implicit operator OrderByExpression(TimeSpanExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(TimeSpanExpressionMediator a) => new GroupByExpression(a);
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
        public static FilterExpression<bool> operator ==(TimeSpanExpressionMediator a, TimeSpan b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(TimeSpanExpressionMediator a, TimeSpan b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(TimeSpanExpressionMediator a, TimeSpan b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(TimeSpanExpressionMediator a, TimeSpan b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(TimeSpanExpressionMediator a, TimeSpan b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(TimeSpanExpressionMediator a, TimeSpan b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(TimeSpan a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(TimeSpan a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(TimeSpan a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(TimeSpan a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(TimeSpan a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(TimeSpan a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region fields
        public static FilterExpression<bool> operator ==(TimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(TimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(TimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(TimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(TimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(TimeSpanExpressionMediator a, TimeSpanFieldExpression b) => new FilterExpression<bool>(a, new TimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(TimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(TimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(TimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(TimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(TimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(TimeSpanExpressionMediator a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(a, new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediators
        public static FilterExpression<bool> operator ==(TimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(TimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(TimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(TimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(TimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(TimeSpanExpressionMediator a, TimeSpanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(TimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(TimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(TimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(TimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(TimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(TimeSpanExpressionMediator a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
