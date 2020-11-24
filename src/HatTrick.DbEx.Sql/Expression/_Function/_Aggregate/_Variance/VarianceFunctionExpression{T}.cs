using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class VarianceFunctionExpression<TValue> : VarianceFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected VarianceFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
