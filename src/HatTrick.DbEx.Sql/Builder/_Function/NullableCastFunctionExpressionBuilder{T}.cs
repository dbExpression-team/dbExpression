using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class NullableCastFunctionExpressionBuilder<TValue> : NullableCastFunctionExpressionBuilder
    {
        #region constructors
        public NullableCastFunctionExpressionBuilder((Type, object) expression) : base(expression)
        {
        }
        #endregion
    }
}
