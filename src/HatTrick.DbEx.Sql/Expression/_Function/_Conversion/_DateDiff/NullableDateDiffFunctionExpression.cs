using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateDiffFunctionExpression : DateDiffFunctionExpression
    {
        #region constructors
        protected NullableDateDiffFunctionExpression(DatePartsExpression datePart, ExpressionMediator startDate, ExpressionMediator endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion
    }
}
