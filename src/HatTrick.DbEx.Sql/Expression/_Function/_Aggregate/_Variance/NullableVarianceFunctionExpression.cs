namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableVarianceFunctionExpression : VarianceFunctionExpression
    {
        #region constructors
        protected NullableVarianceFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
