
namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumCoalesceFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumCoalesceFunctionExpression<TEnum> a) => new EnumExpressionMediator<TEnum>(new EnumExpressionMediator<TEnum>(a));
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
