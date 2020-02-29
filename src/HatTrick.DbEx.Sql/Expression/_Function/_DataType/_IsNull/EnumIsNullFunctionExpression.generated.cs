
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumIsNullFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator SelectExpression<TEnum>(EnumIsNullFunctionExpression<TEnum> a) => new SelectExpression<TEnum>(new ExpressionContainer(a));
        public static implicit operator EnumExpressionMediator<TEnum>(EnumIsNullFunctionExpression<TEnum> a) => new EnumExpressionMediator<TEnum>(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(EnumIsNullFunctionExpression<TEnum> a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(EnumIsNullFunctionExpression<TEnum> a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region filter operators
        #region TValue
        #region
        public static FilterExpression<TEnum> operator ==(EnumIsNullFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<TEnum>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumIsNullFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<TEnum>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(TEnum a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(new LiteralExpression<TEnum>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(TEnum a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(new LiteralExpression<TEnum>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumIsNullFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumIsNullFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum? a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(TEnum? a, EnumIsNullFunctionExpression<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<TEnum> operator ==(EnumIsNullFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumIsNullFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumIsNullFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumIsNullFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
