namespace HatTrick.DbEx.Sql.Expression
{
    public class Int64SelectExpression : SelectExpression<long>,
        Int64Element
    {
        public Int64SelectExpression(IExpressionElement<long> expression)
            : base(expression)
        {

        }

        #region as
        public Int64Element As(string alias)
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
