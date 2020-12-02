using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidFieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params Guid[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<Guid>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<Guid> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<Guid>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<Guid>(GuidFieldExpression a) => new SelectExpression<Guid>(a);
        public static implicit operator GuidExpressionMediator(GuidFieldExpression a) => new GuidExpressionMediator(a);
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
        public static FilterExpressionSet operator ==(GuidFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region Guid
        public static FilterExpressionSet operator ==(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid? a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(GuidFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
