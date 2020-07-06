
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanCoalesceFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool>(BooleanCoalesceFunctionExpression a) => new SelectExpression<bool>(new BooleanExpressionMediator(a));
        public static implicit operator BooleanExpressionMediator(BooleanCoalesceFunctionExpression a) => new BooleanExpressionMediator(a);
        public static implicit operator OrderByExpression(BooleanCoalesceFunctionExpression a) => new OrderByExpression(new BooleanExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(BooleanCoalesceFunctionExpression a) => new GroupByExpression(new BooleanExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new BooleanExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new BooleanExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
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

        #endregion

        #region mediator
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

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region bool
        public static FilterExpression<bool> operator ==(BooleanCoalesceFunctionExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanCoalesceFunctionExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanCoalesceFunctionExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanCoalesceFunctionExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanCoalesceFunctionExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanCoalesceFunctionExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(BooleanCoalesceFunctionExpression a, bool? b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanCoalesceFunctionExpression a, bool? b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanCoalesceFunctionExpression a, bool? b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanCoalesceFunctionExpression a, bool? b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanCoalesceFunctionExpression a, bool? b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanCoalesceFunctionExpression a, bool? b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool? a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool? a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool? a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool? a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool? a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool? a, BooleanCoalesceFunctionExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(BooleanCoalesceFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanCoalesceFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanCoalesceFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanCoalesceFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanCoalesceFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanCoalesceFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(BooleanCoalesceFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(BooleanCoalesceFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(BooleanCoalesceFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(BooleanCoalesceFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(BooleanCoalesceFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(BooleanCoalesceFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
