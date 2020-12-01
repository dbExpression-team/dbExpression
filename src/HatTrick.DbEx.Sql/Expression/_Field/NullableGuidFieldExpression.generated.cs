using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidFieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params Guid[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<Guid>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<Guid> value) => value is object ? new FilterExpression<bool>(this, new InExpression<Guid>(value), FilterExpressionOperator.None) : null;
        public override FilterExpressionSet In(params Guid?[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<Guid?>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<Guid?> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<Guid?>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(Guid value) => new AssignmentExpression(this, new LiteralExpression<Guid>(value));
        public virtual AssignmentExpression Set(GuidElement value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(Guid? value) => new AssignmentExpression(this, new LiteralExpression<Guid?>(value));
        public override AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<Guid?>(DBNull.Value));
        public virtual AssignmentExpression Set(NullableGuidElement value) => new AssignmentExpression(this, value);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableGuidExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableGuidExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<Guid?>(NullableGuidFieldExpression a) => new SelectExpression<Guid?>(a);
        public static implicit operator NullableGuidExpressionMediator(NullableGuidFieldExpression a) => new NullableGuidExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableGuidFieldExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableGuidFieldExpression a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region data types
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region Guid
        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid? a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid? a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableGuidFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
