using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableEnumFieldExpression<TEnum> : NullableFieldExpression<TEnum>,
        ISupportedForSelectFieldExpression<TEnum?>,
        ISupportedForFunctionExpression<CastFunctionExpression, TEnum?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TEnum?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, TEnum?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>,
        ISupportedForFunctionExpression<CountFunctionExpression, TEnum?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, TEnum?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, TEnum?>,
        ISupportedForFunctionExpression<AverageFunctionExpression, TEnum?>
        where TEnum : struct, Enum, IComparable
    {
        protected NullableEnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, TEnum?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableEnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, TEnum?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region filter operators
        #region DBNull
        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEnum> field, DBNull value) => new FilterExpression<TEnum?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEnum> field, DBNull value) => new FilterExpression<TEnum?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(DBNull value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(DBNull value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region TEnum
        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEnum> field, TEnum? value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEnum> field, TEnum? value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(NullableEnumFieldExpression<TEnum> field, TEnum? value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(NullableEnumFieldExpression<TEnum> field, TEnum? value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(NullableEnumFieldExpression<TEnum> field, TEnum? value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(NullableEnumFieldExpression<TEnum> field, TEnum? value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum? value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(TEnum? value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(TEnum? value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(TEnum? value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(TEnum? value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(TEnum? value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(NullableEnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(NullableEnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(NullableEnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(NullableEnumFieldExpression<TEnum> field, TEnum value) => new FilterExpression<TEnum?>(field, new LiteralExpression<TEnum>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(TEnum value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(TEnum value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(TEnum value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(TEnum value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(TEnum value, NullableEnumFieldExpression<TEnum> field) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(NullableEnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(NullableEnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(NullableEnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(NullableEnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(NullableEnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(NullableEnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(NullableEnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(NullableEnumFieldExpression<TEnum> a, EnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(EnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(EnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(EnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(EnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(EnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(EnumFieldExpression<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum?> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum?> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum?> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum?> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum?> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum?> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(ExpressionMediator<TEnum?> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(ExpressionMediator<TEnum?> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(ExpressionMediator<TEnum?> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(ExpressionMediator<TEnum?> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(ExpressionMediator<TEnum?> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(ExpressionMediator<TEnum?> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(NullableEnumFieldExpression<TEnum> a, ExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TEnum?> operator ==(ExpressionMediator<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<TEnum?> operator !=(ExpressionMediator<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator <(ExpressionMediator<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TEnum?> operator <=(ExpressionMediator<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TEnum?> operator >(ExpressionMediator<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TEnum?> operator >=(ExpressionMediator<TEnum> a, NullableEnumFieldExpression<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
