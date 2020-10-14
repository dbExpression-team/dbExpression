
namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumIsNullFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumIsNullFunctionExpression<TEnum> a) => new EnumExpressionMediator<TEnum>(new EnumExpressionMediator<TEnum>(a));
        public static implicit operator OrderByExpression(EnumIsNullFunctionExpression<TEnum> a) => new OrderByExpression(new EnumExpressionMediator<TEnum>(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(EnumIsNullFunctionExpression<TEnum> a) => new GroupByExpression(new EnumExpressionMediator<TEnum>(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.DESC);
        #endregion

        #region filter operators
        #region TEnum
        #region 
        public static FilterExpression<bool> operator ==(EnumIsNullFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<bool>(new EnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(EnumIsNullFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<bool>(new EnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(TEnum a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(TEnum a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(EnumIsNullFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(EnumIsNullFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(TEnum? a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(TEnum? a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(EnumIsNullFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<bool>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(EnumIsNullFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<bool>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(EnumIsNullFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(EnumIsNullFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
