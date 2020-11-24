using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MaximumFunctionExpression<TValue> : MaximumFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected MaximumFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}


