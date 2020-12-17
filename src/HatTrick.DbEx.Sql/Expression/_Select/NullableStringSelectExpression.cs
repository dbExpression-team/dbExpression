namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableStringSelectExpression : SelectExpression<string>,
        NullableStringElement
    {
        public NullableStringSelectExpression(IExpressionElement<string> expression)
            : base(expression)
        {

        }

        public NullableStringSelectExpression(IExpressionElement<string,string> expression)
            : base(expression)
        {

        }

        #region as
        public NullableStringElement As(string alias)
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
