namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableAverageFunctionExpression : AverageFunctionExpression
    {
        #region constructors
        protected NullableAverageFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
