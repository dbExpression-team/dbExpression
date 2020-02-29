namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableIsNullFunctionExpression : IsNullFunctionExpression
    {
        #region constructors
        protected NullableIsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion    
    }
}
