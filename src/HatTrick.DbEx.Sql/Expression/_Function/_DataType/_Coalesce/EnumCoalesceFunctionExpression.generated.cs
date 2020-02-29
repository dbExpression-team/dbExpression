
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumCoalesceFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator SelectExpression<TEnum>(EnumCoalesceFunctionExpression<TEnum> a) => new SelectExpression<TEnum>(new ExpressionContainer(a));
        public static implicit operator EnumExpressionMediator<TEnum>(EnumCoalesceFunctionExpression<TEnum> a) => new EnumExpressionMediator<TEnum>(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(EnumCoalesceFunctionExpression<TEnum> a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(EnumCoalesceFunctionExpression<TEnum> a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region filter operators
        #region TValue
        #region
        public static FilterExpression<TEnum> operator ==(EnumCoalesceFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<TEnum>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumCoalesceFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<TEnum>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(TEnum a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(new LiteralExpression<TEnum>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(TEnum a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(new LiteralExpression<TEnum>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumCoalesceFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumCoalesceFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum? a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(TEnum? a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<TEnum> operator ==(EnumCoalesceFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumCoalesceFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumCoalesceFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumCoalesceFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
