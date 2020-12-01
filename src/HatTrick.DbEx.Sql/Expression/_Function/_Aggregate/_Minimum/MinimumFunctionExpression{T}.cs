using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MinimumFunctionExpression<TValue> : MinimumFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected MinimumFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
