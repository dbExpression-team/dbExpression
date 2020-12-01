
namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumCoalesceFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumCoalesceFunctionExpression<TEnum> a) => new EnumExpressionMediator<TEnum>(new EnumExpressionMediator<TEnum>(a));
        public static implicit operator OrderByExpression(EnumCoalesceFunctionExpression<TEnum> a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(EnumCoalesceFunctionExpression<TEnum> a) => new GroupByExpression(a);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region filter operators
        #region TEnum
        #region 
        #endregion
        #endregion

        #region mediator
        #endregion

        #region alias
        #endregion
        #endregion
    }
}
