namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableSumFunctionExpression : SumFunctionExpression
    {
        #region constructors
        protected NullableSumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
