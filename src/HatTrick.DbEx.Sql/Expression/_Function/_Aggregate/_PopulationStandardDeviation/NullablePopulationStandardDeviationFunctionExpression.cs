using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationStandardDeviationFunctionExpression : PopulationStandardDeviationFunctionExpression
    {
        #region constructors
        protected NullablePopulationStandardDeviationFunctionExpression()
        {
        }

        protected NullablePopulationStandardDeviationFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
