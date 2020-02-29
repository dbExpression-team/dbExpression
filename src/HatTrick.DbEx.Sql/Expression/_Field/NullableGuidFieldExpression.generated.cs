using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidFieldExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid?>(NullableGuidFieldExpression a) => new SelectExpression<Guid?>(new ExpressionContainer(a));
        public static implicit operator NullableGuidExpressionMediator(NullableGuidFieldExpression a) => new NullableGuidExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableGuidFieldExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableGuidFieldExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, DBNull b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(b, typeof(DBNull)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, DBNull b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(b, typeof(DBNull)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator ==(DBNull a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(a, typeof(DBNull)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(DBNull a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(a, typeof(DBNull)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region Guid
        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, Guid b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, Guid b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, Guid b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, Guid b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, Guid b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, Guid b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(Guid a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(Guid a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(Guid a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(Guid a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(Guid a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(Guid a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<Guid?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
