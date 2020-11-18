using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationStandardDeviationFunctionExpression<TValue> : PopulationStandardDeviationFunctionExpression,
        IExpressionElement<TValue>
         where TValue : IComparable
    {
        #region constructors
        protected PopulationStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TValue), isDistinct)
        {

        }
        protected PopulationStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
