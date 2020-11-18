using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationStandardDeviationFunctionExpression<TValue, TNullableValue> : PopulationStandardDeviationFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullablePopulationStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct) 
            : base(expression, typeof(TNullableValue), isDistinct)
        {

        }

        protected NullablePopulationStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, typeof(TNullableValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
