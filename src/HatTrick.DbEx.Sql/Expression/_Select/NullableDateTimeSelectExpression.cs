using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableDateTimeSelectExpression : SelectExpression<DateTime?>,
        NullableDateTimeElement
    {
        public NullableDateTimeSelectExpression(IExpressionElement<DateTime,DateTime?> expression)
            : base(expression)
        {

        }

        #region as
        public NullableDateTimeElement As(string alias)
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
