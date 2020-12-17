namespace HatTrick.DbEx.Sql.Expression
{
    public class Int16SelectExpression : SelectExpression<short>,
        Int16Element
    {
        public Int16SelectExpression(IExpressionElement<short> expression)
            : base(expression)
        {

        }

        #region as
        public Int16Element As(string alias)
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
