namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableExpressionMediator<TValue> : ExpressionMediator<TValue>
    {
        #region constructors
        protected NullableExpressionMediator()
        { 
        }

        public NullableExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion
    }
}
