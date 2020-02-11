using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EnumFieldExpression<TEnum> : FieldExpression<TEnum>,
        ISupportedForSelectFieldExpression<TEnum>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, Enum>,
        ISupportedForFunctionExpression<CastFunctionExpression, Enum>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, Enum>,
        ISupportedForFunctionExpression<CountFunctionExpression, Enum>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, Enum>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, Enum>
        where TEnum : Enum
    {
        public EnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, TEnum>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected EnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, TEnum>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region filter operators
        #region TEnum
        public static FilterExpression<TEnum> operator ==(EnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum> operator !=(EnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator <(EnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum> operator <=(EnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum> operator >(EnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum> operator >=(EnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum> operator ==(TEnum value, EnumFieldExpression<TEnum> field) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum> operator !=(TEnum value, EnumFieldExpression<TEnum> field) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator <(TEnum value, EnumFieldExpression<TEnum> field) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum> operator <=(TEnum value, EnumFieldExpression<TEnum> field) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum> operator >(TEnum value, EnumFieldExpression<TEnum> field) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum> operator >=(TEnum value, EnumFieldExpression<TEnum> field) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<TEnum> operator ==(EnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum> operator !=(EnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator <(EnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum> operator <=(EnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum> operator >(EnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum> operator >=(EnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<TEnum> operator ==(EnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum> operator !=(EnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator <(EnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum> operator <=(EnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum> operator >(EnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum> operator >=(EnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
