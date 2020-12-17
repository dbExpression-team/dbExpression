namespace HatTrick.DbEx.Sql.Expression
{
    public class DecimalSelectExpression : SelectExpression<decimal>,
        DecimalElement
    {
        public DecimalSelectExpression(IExpressionElement<decimal> expression)
            : base(expression)
        {

        }

        #region as
        public DecimalElement As(string alias)
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
