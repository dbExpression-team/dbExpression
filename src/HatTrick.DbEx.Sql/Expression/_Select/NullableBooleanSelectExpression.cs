namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableBooleanSelectExpression : SelectExpression<bool?>,
        NullableBooleanElement
    {
        public NullableBooleanSelectExpression(IExpressionElement<bool,bool?> expression)
            : base(expression)
        {

        }

        #region as
        public NullableBooleanElement As(string alias)
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
