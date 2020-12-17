namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableDoubleSelectExpression : SelectExpression<double?>,
        NullableDoubleElement
    {
        public NullableDoubleSelectExpression(IExpressionElement<double,double?> expression)
            : base(expression)
        {

        }

        #region as
        public NullableDoubleElement As(string alias)
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
