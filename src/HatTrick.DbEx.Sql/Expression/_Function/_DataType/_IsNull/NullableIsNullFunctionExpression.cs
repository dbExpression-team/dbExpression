namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableIsNullFunctionExpression : IsNullFunctionExpression
    {
        #region constructors
        protected NullableIsNullFunctionExpression(ExpressionMediator expression, ExpressionMediator value) : base(expression, value)
        {
        }
        #endregion    
    }
}
