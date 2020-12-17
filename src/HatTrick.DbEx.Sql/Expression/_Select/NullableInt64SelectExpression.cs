namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableInt64SelectExpression : SelectExpression<long?>,
        NullableInt64Element
    {
        public NullableInt64SelectExpression(IExpressionElement<long,long?> expression)
            : base(expression)
        {

        }

        #region as
        public NullableInt64Element As(string alias)
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
