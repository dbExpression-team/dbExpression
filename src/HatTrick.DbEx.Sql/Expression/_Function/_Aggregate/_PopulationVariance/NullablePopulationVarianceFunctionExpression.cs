using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationVarianceFunctionExpression : PopulationVarianceFunctionExpression
    {
        #region constructors
        protected NullablePopulationVarianceFunctionExpression()
        {
        }

        protected NullablePopulationVarianceFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
