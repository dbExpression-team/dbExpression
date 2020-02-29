
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetDateAddFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTimeOffset>(DateTimeOffsetDateAddFunctionExpression a) => new SelectExpression<DateTimeOffset>(new ExpressionContainer(a));
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetDateAddFunctionExpression a) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(DateTimeOffsetDateAddFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeOffsetDateAddFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion

        #region mediator
        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
