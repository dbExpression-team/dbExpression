using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationVarianceFunctionExpression<TValue> : NullablePopulationVarianceFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullablePopulationVarianceFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
