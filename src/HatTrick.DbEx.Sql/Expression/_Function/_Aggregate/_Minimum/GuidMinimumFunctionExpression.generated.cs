
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid>(GuidMinimumFunctionExpression a) => new SelectExpression<Guid>(new ExpressionContainer(a));
        public static implicit operator GuidExpressionMediator(GuidMinimumFunctionExpression a) => new GuidExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(GuidMinimumFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
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
        #region Guid
        public static FilterExpression<Guid> operator ==(GuidMinimumFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(GuidMinimumFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(GuidMinimumFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(GuidMinimumFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(GuidMinimumFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(GuidMinimumFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(Guid a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(Guid a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(Guid a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(Guid a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(Guid a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(Guid a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(GuidMinimumFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(GuidMinimumFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(GuidMinimumFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(GuidMinimumFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(GuidMinimumFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(GuidMinimumFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(Guid? a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(Guid? a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(Guid? a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(Guid? a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(Guid? a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(Guid? a, GuidMinimumFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<Guid> operator ==(GuidMinimumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(GuidMinimumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid> operator <(GuidMinimumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid> operator <=(GuidMinimumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid> operator >(GuidMinimumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid> operator >=(GuidMinimumFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(GuidMinimumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(GuidMinimumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(GuidMinimumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(GuidMinimumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(GuidMinimumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(GuidMinimumFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
