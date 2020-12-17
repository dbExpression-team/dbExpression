namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableInt32SelectExpression : SelectExpression<int?>,
        NullableInt32Element
    {
        public NullableInt32SelectExpression(IExpressionElement<int,int?> expression)
            : base(expression)
        {

        }

        #region as
        public NullableInt32Element As(string alias)
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
