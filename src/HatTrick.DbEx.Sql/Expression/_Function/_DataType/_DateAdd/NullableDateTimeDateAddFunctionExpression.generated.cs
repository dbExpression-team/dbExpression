using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeDateAddFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDateTimeExpressionMediator(NullableDateTimeDateAddFunctionExpression a) => new NullableDateTimeExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableDateTimeDateAddFunctionExpression a) => new OrderByExpression(new DateTimeExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableDateTimeDateAddFunctionExpression a) => new GroupByExpression(new DateTimeExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeDateAddFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #endregion

        #region mediator
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpressionSet operator ==(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableDateTimeDateAddFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTime a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableDateTimeDateAddFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTime? a, NullableDateTimeDateAddFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableDateTimeDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableDateTimeDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
