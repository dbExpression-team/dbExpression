using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateDiffFunctionExpression : DateDiffFunctionExpression
    {
        #region constructors
        protected NullableDateDiffFunctionExpression(ExpressionContainer datePart, ExpressionMediator startDate, ExpressionMediator endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion
    }
}
