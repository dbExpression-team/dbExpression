using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCoalesceFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid?>(NullableGuidCoalesceFunctionExpression a) => new SelectExpression<Guid?>(new ExpressionContainer(a));
        public static implicit operator NullableGuidExpressionMediator(NullableGuidCoalesceFunctionExpression a) => new NullableGuidExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableGuidCoalesceFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableGuidCoalesceFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
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

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region Guid
        public static FilterExpression<Guid> operator ==(NullableGuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(NullableGuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(NullableGuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(NullableGuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(NullableGuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(NullableGuidCoalesceFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(Guid a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(Guid a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(Guid a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(Guid a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(Guid a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(Guid a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(NullableGuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(NullableGuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(NullableGuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(NullableGuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(NullableGuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(NullableGuidCoalesceFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(Guid? a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(Guid? a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(Guid? a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(Guid? a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(Guid? a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(Guid? a, NullableGuidCoalesceFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<Guid> operator ==(NullableGuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(NullableGuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(NullableGuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(NullableGuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(NullableGuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(NullableGuidCoalesceFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NullableGuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(NullableGuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(NullableGuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(NullableGuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(NullableGuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(NullableGuidCoalesceFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
