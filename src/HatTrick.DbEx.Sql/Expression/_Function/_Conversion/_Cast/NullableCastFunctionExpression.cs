namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCastFunctionExpression : CastFunctionExpression
    {
        #region constructors
        protected NullableCastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion    
    }
}
