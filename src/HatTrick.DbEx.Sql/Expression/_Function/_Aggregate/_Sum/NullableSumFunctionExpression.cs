namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableSumFunctionExpression : SumFunctionExpression
    {
        #region constructors
        protected NullableSumFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
