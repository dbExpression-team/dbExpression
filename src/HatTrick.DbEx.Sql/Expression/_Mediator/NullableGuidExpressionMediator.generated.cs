using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid?>(NullableGuidExpressionMediator a) => new SelectExpression<Guid?>(a);
        public static implicit operator OrderByExpression(NullableGuidExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableGuidExpressionMediator a) => new GroupByExpression(a);
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
        public static FilterExpressionSet operator ==(NullableGuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidExpressionMediator a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Guid a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Guid a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Guid a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Guid a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Guid a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableGuidExpressionMediator a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidExpressionMediator a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidExpressionMediator a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidExpressionMediator a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidExpressionMediator a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidExpressionMediator a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Guid? a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid? a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Guid? a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Guid? a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Guid? a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Guid? a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidExpressionMediator a, GuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidExpressionMediator a, NullableGuidFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidExpressionMediator a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidExpressionMediator a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
