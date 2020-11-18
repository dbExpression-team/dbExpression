using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationVarianceFunctionExpression<TValue> : PopulationVarianceFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected PopulationVarianceFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TValue), isDistinct)
        {

        }

        protected PopulationVarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
