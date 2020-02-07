using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class BooleanFieldExpression : FieldExpression<bool>,
        ISupportedForSelectFieldExpression<bool>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, bool>,
        ISupportedForFunctionExpression<CastFunctionExpression, bool>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, bool>,
        ISupportedForFunctionExpression<CountFunctionExpression, bool>
    {
        protected BooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, bool>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected BooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, bool>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region filter operators
        #region bool
        public static FilterExpression<bool> operator ==(BooleanFieldExpression field, bool? value) => new FilterExpression<bool>(field, new LiteralExpression<bool?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(BooleanFieldExpression field, bool? value) => new FilterExpression<bool>(field, new LiteralExpression<bool?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(bool? value, BooleanFieldExpression field) => new FilterExpression<bool>(new LiteralExpression<bool?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(bool? value, BooleanFieldExpression field) => new FilterExpression<bool>(new LiteralExpression<bool?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(BooleanFieldExpression field, bool value) => new FilterExpression<bool>(field, new LiteralExpression<bool>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(BooleanFieldExpression field, bool value) => new FilterExpression<bool>(field, new LiteralExpression<bool>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(bool value, BooleanFieldExpression field) => new FilterExpression<bool>(new LiteralExpression<bool>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(bool value, BooleanFieldExpression field) => new FilterExpression<bool>(new LiteralExpression<bool>(value), field, FilterExpressionOperator.NotEqual);
        #endregion

        #region field
        public static FilterExpression<bool?> operator ==(BooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(BooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, ExpressionMediator<bool> b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, ExpressionMediator<bool> b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(ExpressionMediator<bool> a, BooleanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(ExpressionMediator<bool> a, BooleanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, ExpressionMediator<bool?> b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, ExpressionMediator<bool?> b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(ExpressionMediator<bool?> a, BooleanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(ExpressionMediator<bool?> a, BooleanFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
