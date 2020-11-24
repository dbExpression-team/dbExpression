using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidFieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params Guid[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(this), new GuidExpressionMediator(new InExpression<Guid>(value)), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<Guid> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(this), new GuidExpressionMediator(new InExpression<Guid>(value)), FilterExpressionOperator.None)) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(Guid value) => new AssignmentExpression(this, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));
        public virtual AssignmentExpression Set(GuidElement value) => new AssignmentExpression(this, value);
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
        public static FilterExpressionSet operator ==(GuidFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), new GuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>()), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        #endregion

        #region Guid
        public static FilterExpressionSet operator ==(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
