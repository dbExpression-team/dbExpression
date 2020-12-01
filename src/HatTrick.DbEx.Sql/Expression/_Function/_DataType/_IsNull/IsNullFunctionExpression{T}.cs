namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class IsNullFunctionExpression<TValue> : IsNullFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected IsNullFunctionExpression(IExpressionElement expression, IExpressionElement value) : base(expression, typeof(TValue), value)
        {

        }
        #endregion
    }
}
