namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullablePopulationVarianceFunctionExpression : PopulationVarianceFunctionExpression
    {
        #region constructors
        protected NullablePopulationVarianceFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
