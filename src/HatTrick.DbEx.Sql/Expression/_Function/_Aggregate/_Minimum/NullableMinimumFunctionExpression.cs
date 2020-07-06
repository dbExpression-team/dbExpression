namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMinimumFunctionExpression : MinimumFunctionExpression
    {
        #region constructors
        protected NullableMinimumFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
