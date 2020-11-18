using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateDiffFunctionExpression<TValue, TNullableValue> : DateDiffFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableDateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate)
            : base(datePart, startDate, endDate, typeof(TNullableValue))
        {

        }

        protected NullableDateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate, string alias)
            : base(datePart, startDate, endDate, typeof(TNullableValue), alias)
        {

        }
        #endregion
    }
}
