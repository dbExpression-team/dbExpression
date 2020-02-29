namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableStandardDeviationFunctionExpression : StandardDeviationFunctionExpression
    {
        #region constructors
        protected NullableStandardDeviationFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
