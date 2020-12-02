
namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumIsNullFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumIsNullFunctionExpression<TEnum> a) => new EnumExpressionMediator<TEnum>(new EnumExpressionMediator<TEnum>(a));
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
