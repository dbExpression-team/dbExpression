using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationVarianceFunctionExpression<TValue> : PopulationVarianceFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected PopulationVarianceFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
