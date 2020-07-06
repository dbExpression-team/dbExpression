namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableExpressionMediator<TValue> : ExpressionMediator<TValue>
    {
        #region constructors
        protected NullableExpressionMediator()
        { }

        protected NullableExpressionMediator(IDbExpression expression)
            : base(expression)
        {
        }
        #endregion
    }
}
