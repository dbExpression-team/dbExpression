using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumIsNullFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumIsNullFunctionExpression<TEnum> a) => new NullableEnumExpressionMediator<TEnum>(new NullableEnumExpressionMediator<TEnum>(a));
        public static implicit operator OrderByExpression(NullableEnumIsNullFunctionExpression<TEnum> a) => new OrderByExpression(new NullableEnumExpressionMediator<TEnum>(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableEnumIsNullFunctionExpression<TEnum> a) => new GroupByExpression(new NullableEnumExpressionMediator<TEnum>(a));
        #endregion
        
        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableEnumExpressionMediator<TEnum>(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableEnumExpressionMediator<TEnum>(this), OrderExpressionDirection.DESC);
        #endregion
        
        #region filter operators
        #region TEnum
        public static FilterExpression<bool?> operator ==(NullableEnumIsNullFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableEnumIsNullFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(TEnum a, NullableEnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(TEnum a, NullableEnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(TEnum? a, NullableEnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(TEnum? a, NullableEnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableEnumIsNullFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableEnumIsNullFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NullableEnumIsNullFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableEnumIsNullFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
