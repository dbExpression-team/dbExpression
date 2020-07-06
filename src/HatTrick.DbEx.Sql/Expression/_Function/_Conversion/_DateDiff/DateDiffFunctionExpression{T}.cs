using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateDiffFunctionExpression<TValue> : DateDiffFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected DateDiffFunctionExpression(ExpressionContainer datePart, ExpressionMediator startDate, ExpressionMediator endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion
    }
}
