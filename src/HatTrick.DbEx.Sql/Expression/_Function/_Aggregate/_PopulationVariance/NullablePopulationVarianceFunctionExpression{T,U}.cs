using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationVarianceFunctionExpression<TValue, TNullableValue> : PopulationVarianceFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullablePopulationVarianceFunctionExpression(IExpressionElement expression) : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
