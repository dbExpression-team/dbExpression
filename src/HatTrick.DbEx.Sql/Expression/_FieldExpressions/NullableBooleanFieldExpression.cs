using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableBooleanFieldExpression : NullableFieldExpression<bool>,
        ISupportedForSelectFieldExpression<bool?>,
        ISupportedForFunctionExpression<CastFunctionExpression, bool?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, bool?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, bool?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>,
        ISupportedForFunctionExpression<CountFunctionExpression, bool?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, bool?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, bool?>
    {
        protected NullableBooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, bool?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableBooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, bool?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression field, DBNull value) => new FilterExpression<bool?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression field, DBNull value) => new FilterExpression<bool?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(DBNull value, NullableBooleanFieldExpression field) => new FilterExpression<bool?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(DBNull value, NullableBooleanFieldExpression field) => new FilterExpression<bool?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression field, bool? value) => new FilterExpression<bool?>(field, new LiteralExpression<bool?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression field, bool? value) => new FilterExpression<bool?>(field, new LiteralExpression<bool?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(bool? value, NullableBooleanFieldExpression field) => new FilterExpression<bool?>(new LiteralExpression<bool?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(bool? value, NullableBooleanFieldExpression field) => new FilterExpression<bool?>(new LiteralExpression<bool?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression field, bool value) => new FilterExpression<bool?>(field, new LiteralExpression<bool>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression field, bool value) => new FilterExpression<bool?>(field, new LiteralExpression<bool>(value), FilterExpressionOperator.NotEqual);

       public static FilterExpression<bool?> operator ==(bool value, NullableBooleanFieldExpression field) => new FilterExpression<bool?>(new LiteralExpression<bool>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(bool value, NullableBooleanFieldExpression field) => new FilterExpression<bool?>(new LiteralExpression<bool>(value), field, FilterExpressionOperator.NotEqual);
        #endregion

        #region field
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(BooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(BooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, ExpressionMediator<bool?> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, ExpressionMediator<bool?> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<bool?> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(ExpressionMediator<bool?> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, ExpressionMediator<bool> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, ExpressionMediator<bool> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<bool> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(ExpressionMediator<bool> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
