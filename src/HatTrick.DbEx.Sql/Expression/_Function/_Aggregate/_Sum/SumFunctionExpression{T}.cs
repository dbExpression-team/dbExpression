using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class SumFunctionExpression<TValue> : SumFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected SumFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
