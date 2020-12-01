using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumCoalesceFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumCoalesceFunctionExpression<TEnum> a) => new NullableEnumExpressionMediator<TEnum>(new NullableEnumExpressionMediator<TEnum>(a));
        public static implicit operator OrderByExpression(NullableEnumCoalesceFunctionExpression<TEnum> a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableEnumCoalesceFunctionExpression<TEnum> a) => new GroupByExpression(a);
        #endregion
        
        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion
        
        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableEnumCoalesceFunctionExpression<TEnum> a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumCoalesceFunctionExpression<TEnum> a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TEnum?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TEnum?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region TEnum
        #endregion

        #region mediator
        #endregion

        #region alias
        #endregion
        #endregion
    }
}
