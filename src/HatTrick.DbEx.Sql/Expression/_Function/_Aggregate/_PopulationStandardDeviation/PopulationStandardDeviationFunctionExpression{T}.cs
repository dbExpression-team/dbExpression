using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationStandardDeviationFunctionExpression<TValue> : PopulationStandardDeviationFunctionExpression
         where TValue : IComparable
    {
        #region constructors
        protected PopulationStandardDeviationFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
