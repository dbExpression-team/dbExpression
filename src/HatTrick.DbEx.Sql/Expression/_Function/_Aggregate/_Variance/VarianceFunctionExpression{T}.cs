using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class VarianceFunctionExpression<TValue> : VarianceFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected VarianceFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
