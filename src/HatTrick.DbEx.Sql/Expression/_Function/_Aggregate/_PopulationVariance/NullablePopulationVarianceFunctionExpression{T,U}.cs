using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationVarianceFunctionExpression<TValue, TNullableValue> : PopulationVarianceFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullablePopulationVarianceFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TNullableValue), isDistinct)
        {

        }

        protected NullablePopulationVarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TNullableValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
