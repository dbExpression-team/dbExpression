using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationStandardDeviationFunctionExpression<TValue, TNullableValue> : PopulationStandardDeviationFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullablePopulationStandardDeviationFunctionExpression(IExpressionElement expression) 
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
