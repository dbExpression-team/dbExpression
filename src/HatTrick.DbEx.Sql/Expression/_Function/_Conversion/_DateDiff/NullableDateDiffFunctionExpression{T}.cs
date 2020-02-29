using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateDiffFunctionExpression<TValue> : NullableDateDiffFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableDateDiffFunctionExpression(ExpressionContainer datePart, ExpressionContainer startDate, ExpressionContainer endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion
    }
}
