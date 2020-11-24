using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid>(GuidExpressionMediator a) => new SelectExpression<Guid>(a);
        public static implicit operator OrderByExpression(GuidExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(GuidExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region data type
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion
        #endregion

        #region filter operators
        #region Guid
        public static FilterExpressionSet operator ==(GuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Guid a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Guid a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Guid a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Guid a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Guid a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(GuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, new GuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(GuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(GuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(GuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(GuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(GuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(GuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(GuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
