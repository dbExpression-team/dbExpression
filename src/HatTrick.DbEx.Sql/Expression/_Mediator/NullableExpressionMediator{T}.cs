namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableExpressionMediator<TValue> : ExpressionMediator<TValue>
    {
        #region constructors
        protected NullableExpressionMediator()
        { 
        }

        protected NullableExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion
    }
}
