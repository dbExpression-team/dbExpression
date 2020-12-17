using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GuidSelectExpression : SelectExpression<Guid>,
        GuidElement
    {
        public GuidSelectExpression(IExpressionElement<Guid> expression)
            : base(expression)
        {

        }

        #region as
        public GuidElement As(string alias)
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
