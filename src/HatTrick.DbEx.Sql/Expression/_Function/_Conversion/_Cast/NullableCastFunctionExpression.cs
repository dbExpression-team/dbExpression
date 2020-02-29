namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCastFunctionExpression : CastFunctionExpression
    {
        #region constructors
        protected NullableCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion    
    }
}
