using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class CastFunctionExpressionBuilder<TValue> : CastFunctionExpressionBuilder
    {
        #region constructors
        public CastFunctionExpressionBuilder(ExpressionMediator expression) : base(expression)
        {
        }
        #endregion
    }
}
