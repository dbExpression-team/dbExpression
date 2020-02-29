namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationStandardDeviationFunctionExpression : PopulationStandardDeviationFunctionExpression
    {
        #region constructors
        protected NullablePopulationStandardDeviationFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
