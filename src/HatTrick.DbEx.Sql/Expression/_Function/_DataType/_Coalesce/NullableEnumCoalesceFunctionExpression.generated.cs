using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumCoalesceFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumCoalesceFunctionExpression<TEnum> a) => new NullableEnumExpressionMediator<TEnum>(new NullableEnumExpressionMediator<TEnum>(a));
        public static implicit operator OrderByExpression(NullableEnumCoalesceFunctionExpression<TEnum> a) => new OrderByExpression(new NullableEnumExpressionMediator<TEnum>(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableEnumCoalesceFunctionExpression<TEnum> a) => new GroupByExpression(new NullableEnumExpressionMediator<TEnum>(a));
        #endregion
        
        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableEnumExpressionMediator<TEnum>(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableEnumExpressionMediator<TEnum>(this), OrderExpressionDirection.DESC);
        #endregion
        
        #region filter operators
        #region TEnum
        public static FilterExpressionSet operator ==(NullableEnumCoalesceFunctionExpression<TEnum> a, TEnum b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumCoalesceFunctionExpression<TEnum> a, TEnum b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(TEnum a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TEnum a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(TEnum? a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TEnum? a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual));
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(NullableEnumCoalesceFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumCoalesceFunctionExpression<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableEnumCoalesceFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumCoalesceFunctionExpression<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
