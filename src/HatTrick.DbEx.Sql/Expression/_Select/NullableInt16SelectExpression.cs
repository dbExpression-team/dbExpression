namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableInt16SelectExpression : SelectExpression<short?>,
        NullableInt16Element
    {
        public NullableInt16SelectExpression(IExpressionElement<short,short?> expression)
            : base(expression)
        {

        }

        #region as
        public NullableInt16Element As(string alias)
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
