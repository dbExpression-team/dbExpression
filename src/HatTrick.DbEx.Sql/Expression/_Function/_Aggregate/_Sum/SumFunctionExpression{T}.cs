using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class SumFunctionExpression<TValue> : SumFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected SumFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
