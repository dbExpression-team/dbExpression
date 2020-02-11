using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableGuidFieldExpression : NullableFieldExpression<Guid>,
        ISupportedForSelectFieldExpression<Guid?>,
        ISupportedForFunctionExpression<CastFunctionExpression, Guid?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, Guid?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, Guid?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>,
        ISupportedForFunctionExpression<CountFunctionExpression, Guid?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, Guid?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, Guid?>
    {
        protected NullableGuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, Guid?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableGuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, Guid?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region filter operators
        #region DBNull
        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression field, DBNull value) => new FilterExpression<Guid?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression field, DBNull value) => new FilterExpression<Guid?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator ==(DBNull value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(DBNull value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region Guid
        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression field, Guid? value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression field, Guid? value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression field, Guid? value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression field, Guid? value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression field, Guid? value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression field, Guid? value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(Guid? value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(Guid? value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(Guid? value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(Guid? value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(Guid? value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(Guid? value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression field, Guid value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression field, Guid value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression field, Guid value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression field, Guid value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression field, Guid value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression field, Guid value) => new FilterExpression<Guid?>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(Guid value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(Guid value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(Guid value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(Guid value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(Guid value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(Guid value, NullableGuidFieldExpression field) => new FilterExpression<Guid?>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(GuidFieldExpression a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(ExpressionMediator<Guid?> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(ExpressionMediator<Guid?> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(ExpressionMediator<Guid?> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(ExpressionMediator<Guid?> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(ExpressionMediator<Guid?> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(ExpressionMediator<Guid?> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NullableGuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableGuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NullableGuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NullableGuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NullableGuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NullableGuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(ExpressionMediator<Guid> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(ExpressionMediator<Guid> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(ExpressionMediator<Guid> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(ExpressionMediator<Guid> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(ExpressionMediator<Guid> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(ExpressionMediator<Guid> a, NullableGuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
