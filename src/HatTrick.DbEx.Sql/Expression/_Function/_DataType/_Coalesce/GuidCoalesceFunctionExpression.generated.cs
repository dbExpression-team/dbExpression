
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidCoalesceFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid>(GuidCoalesceFunctionExpression a) => new SelectExpression<Guid>(new GuidExpressionMediator(a));
        public static implicit operator GuidExpressionMediator(GuidCoalesceFunctionExpression a) => new GuidExpressionMediator(a);
        public static implicit operator OrderByExpression(GuidCoalesceFunctionExpression a) => new OrderByExpression(new GuidExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(GuidCoalesceFunctionExpression a) => new GroupByExpression(new GuidExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.DESC);
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
        #region Guid
        public static FilterExpression<bool> operator ==(GuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(GuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(GuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(GuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(GuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(GuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(Guid a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Guid a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Guid a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Guid a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Guid a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Guid a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(GuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(GuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(GuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(GuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(GuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(GuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(Guid? a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Guid? a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Guid? a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Guid? a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Guid? a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Guid? a, GuidCoalesceFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(GuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(GuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(GuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(GuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(GuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(GuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(GuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(GuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(GuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(GuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(GuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(GuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
