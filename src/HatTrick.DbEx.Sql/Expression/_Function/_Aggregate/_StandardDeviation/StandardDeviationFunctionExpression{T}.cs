using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class StandardDeviationFunctionExpression<TValue> : StandardDeviationFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected StandardDeviationFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
