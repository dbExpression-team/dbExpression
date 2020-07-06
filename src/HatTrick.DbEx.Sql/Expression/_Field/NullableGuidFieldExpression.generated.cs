using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidFieldExpression
    {
        #region in value set
        public override FilterExpression In(params Guid[] value) => value != null ? new FilterExpression<Guid>(new NullableGuidExpressionMediator(this), new GuidExpressionMediator(new LiteralExpression<Guid[]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region isnull
        public override FilterExpression<bool> IsNull() => new FilterExpression<bool>(new NullableGuidExpressionMediator(this), new NullableGuidExpressionMediator(new LiteralExpression<Guid>(DBNull.Value)), FilterExpressionOperator.Equal);
        public override FilterExpression<bool> IsNotNull() => new FilterExpression<bool>(new NullableGuidExpressionMediator(this), new NullableGuidExpressionMediator(new LiteralExpression<Guid>(DBNull.Value)), FilterExpressionOperator.NotEqual);
        #endregion

        #region set
        public override AssignmentExpression Set(Guid value) => new AssignmentExpression(new NullableGuidExpressionMediator(this), new GuidExpressionMediator(new LiteralExpression<Guid>(value)));
        public override AssignmentExpression Set(ExpressionMediator<Guid> value) => new AssignmentExpression(new NullableGuidExpressionMediator(this), value);
        public override AssignmentExpression Set(Guid? value) => new AssignmentExpression(new NullableGuidExpressionMediator(this), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(value)));
        public override AssignmentExpression Set(NullableExpressionMediator<Guid> value) => new AssignmentExpression(new NullableGuidExpressionMediator(this), value);
        #endregion

        #region insert
        public override InsertExpression Insert(Guid value) => new InsertExpression(this, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));
        public override InsertExpression Insert(Guid? value) => new InsertExpression(this, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableGuidExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableGuidExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<Guid?>(NullableGuidFieldExpression a) => new SelectExpression<Guid?>(new NullableGuidExpressionMediator(a));
        public static implicit operator NullableGuidExpressionMediator(NullableGuidFieldExpression a) => new NullableGuidExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableGuidFieldExpression a) => new OrderByExpression(new NullableGuidExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableGuidFieldExpression a) => new GroupByExpression(new NullableGuidExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableGuidFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableGuidFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool?> operator ==(NullableGuidFieldExpression a, Guid b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableGuidFieldExpression a, Guid b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableGuidFieldExpression a, Guid b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableGuidFieldExpression a, Guid b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableGuidFieldExpression a, Guid b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableGuidFieldExpression a, Guid b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Guid a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Guid a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Guid a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Guid a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Guid a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Guid a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableGuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Guid? a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
