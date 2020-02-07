using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class GuidFieldExpression : FieldExpression<Guid>,
        ISupportedForSelectFieldExpression<Guid>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CastFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CountFunctionExpression, Guid>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, Guid>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, Guid>
    {
        protected GuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, Guid>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected GuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, Guid>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region filter operators
        #region Guid
        public static FilterExpression<Guid> operator ==(GuidFieldExpression field, Guid? value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(GuidFieldExpression field, Guid? value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(GuidFieldExpression field, Guid? value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(GuidFieldExpression field, Guid? value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(GuidFieldExpression field, Guid? value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(GuidFieldExpression field, Guid? value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(Guid? value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(Guid? value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(Guid? value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(Guid? value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(Guid? value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(Guid? value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(GuidFieldExpression field, Guid value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(GuidFieldExpression field, Guid value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(GuidFieldExpression field, Guid value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(GuidFieldExpression field, Guid value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(GuidFieldExpression field, Guid value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(GuidFieldExpression field, Guid value) => new FilterExpression<Guid>(field, new LiteralExpression<Guid>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(Guid value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(Guid value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(Guid value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(Guid value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(Guid value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(Guid value, GuidFieldExpression field) => new FilterExpression<Guid>(new LiteralExpression<Guid>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<Guid?> operator ==(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(GuidFieldExpression a, GuidFieldExpression b) => new FilterExpression<Guid?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<Guid> operator ==(GuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(GuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(GuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(GuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(GuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(GuidFieldExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(ExpressionMediator<Guid> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(ExpressionMediator<Guid> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(ExpressionMediator<Guid> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(ExpressionMediator<Guid> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(ExpressionMediator<Guid> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(ExpressionMediator<Guid> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(GuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(GuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(GuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(GuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(GuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(GuidFieldExpression a, ExpressionMediator<Guid?> b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(ExpressionMediator<Guid?> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(ExpressionMediator<Guid?> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(ExpressionMediator<Guid?> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(ExpressionMediator<Guid?> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(ExpressionMediator<Guid?> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(ExpressionMediator<Guid?> a, GuidFieldExpression b) => new FilterExpression<Guid>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
