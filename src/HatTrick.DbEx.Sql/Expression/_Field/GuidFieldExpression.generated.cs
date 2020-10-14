using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidFieldExpression
    {
        #region in value set
        public override FilterExpression<bool> In(params Guid[] value) => value is object ? new FilterExpression<bool>(new GuidExpressionMediator(this), new GuidExpressionMediator(new InExpression<Guid>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<Guid> value) => value is object ? new FilterExpression<bool>(new GuidExpressionMediator(this), new GuidExpressionMediator(new InExpression<Guid>(value)), FilterExpressionOperator.None) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(Guid value) => new AssignmentExpression(this, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));
        public override AssignmentExpression Set(ExpressionMediator<Guid> value) => new AssignmentExpression(this, value);
        #endregion

        #region insert
        public override InsertExpression Insert(Guid value) => new InsertExpression(this, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<Guid>(GuidFieldExpression a) => new SelectExpression<Guid>(new GuidExpressionMediator(a));
        public static implicit operator GuidExpressionMediator(GuidFieldExpression a) => new GuidExpressionMediator(a);
        public static implicit operator OrderByExpression(GuidFieldExpression a) => new OrderByExpression(new GuidExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(GuidFieldExpression a) => new GroupByExpression(new GuidExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region data type
        #endregion

        #region fields
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(GuidFieldExpression a, DBNull b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(GuidFieldExpression a, DBNull b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool> operator ==(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(GuidFieldExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Guid a, GuidFieldExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(GuidFieldExpression a, Guid? b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Guid? a, GuidFieldExpression b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool> operator ==(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
