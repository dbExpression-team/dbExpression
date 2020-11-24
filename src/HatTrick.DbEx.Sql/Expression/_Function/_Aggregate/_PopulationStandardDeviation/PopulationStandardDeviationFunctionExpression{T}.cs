using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class PopulationStandardDeviationFunctionExpression<TValue> : PopulationStandardDeviationFunctionExpression,
        IExpressionElement<TValue>
         where TValue : IComparable
    {
        #region constructors
        protected PopulationStandardDeviationFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
