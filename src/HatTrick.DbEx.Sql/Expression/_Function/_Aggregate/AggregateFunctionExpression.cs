namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class AggregateFunctionExpression : FunctionExpression
    {
        #region constructors
        protected AggregateFunctionExpression()
        { 
        
        }

        protected AggregateFunctionExpression(ExpressionMediator expression) : base(expression)
        {
        }
        #endregion
    }
}
