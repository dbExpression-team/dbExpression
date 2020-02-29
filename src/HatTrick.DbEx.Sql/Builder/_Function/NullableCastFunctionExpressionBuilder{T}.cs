using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class NullableCastFunctionExpressionBuilder<TValue> : NullableCastFunctionExpressionBuilder
    {
        #region constructors
        public NullableCastFunctionExpressionBuilder(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion
    }
}
