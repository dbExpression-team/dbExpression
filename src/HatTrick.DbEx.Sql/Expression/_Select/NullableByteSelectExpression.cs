namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableByteSelectExpression : SelectExpression<byte?>,
        NullableByteElement
    {
        public NullableByteSelectExpression(IExpressionElement<byte,byte?> expression)
            : base(expression)
        {

        }

        #region as
        public NullableByteElement As(string alias)
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
