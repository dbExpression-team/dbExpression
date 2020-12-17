namespace HatTrick.DbEx.Sql.Expression
{
    public class StringSelectExpression : SelectExpression<string>,
        StringElement
    {
        public StringSelectExpression(IExpressionElement<string> expression)
            : base(expression)
        {

        }

        #region as
        public StringElement As(string alias)
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
