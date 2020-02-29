namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationVarianceFunctionExpression : PopulationVarianceFunctionExpression
    {
        #region constructors
        protected NullablePopulationVarianceFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
