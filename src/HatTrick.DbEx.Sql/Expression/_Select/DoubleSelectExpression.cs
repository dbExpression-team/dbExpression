namespace HatTrick.DbEx.Sql.Expression
{
    public class DoubleSelectExpression : SelectExpression<double>,
        DoubleElement
    {
        public DoubleSelectExpression(IExpressionElement<double> expression)
            : base(expression)
        {

        }

        #region as
        public DoubleElement As(string alias)
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
