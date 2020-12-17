namespace HatTrick.DbEx.Sql.Expression
{
    public class Int32SelectExpression : SelectExpression<int>,
        Int32Element
    {
        public Int32SelectExpression(IExpressionElement<int> expression)
            : base(expression)
        { 
        
        }

        #region as
        public Int32Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region order by
        OrderByExpression AnyElement.Asc => throw new DbExpressionException("Select expressions cannot be used in Order By clauses.");

        OrderByExpression AnyElement.Desc => throw new DbExpressionException("Select expressions cannot be used in Order By clauses.");
        #endregion
    }
}
