using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DateTimeOffsetSelectExpression : SelectExpression<DateTimeOffset>,
        DateTimeOffsetElement
    {
        public DateTimeOffsetSelectExpression(IExpressionElement<DateTimeOffset> expression)
            : base(expression)
        {

        }

        #region as
        public DateTimeOffsetElement As(string alias)
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
