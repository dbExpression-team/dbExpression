using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationVarianceFunctionExpression<TValue> : PopulationVarianceFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected PopulationVarianceFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
