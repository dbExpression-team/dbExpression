using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationVarianceFunctionExpression<TValue> : PopulationVarianceFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected PopulationVarianceFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
