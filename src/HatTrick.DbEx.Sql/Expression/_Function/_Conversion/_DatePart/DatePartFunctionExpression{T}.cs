using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DatePartFunctionExpression<TValue> : DatePartFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected DatePartFunctionExpression(DatePartsExpression datePart, DateTimeElement startDate) : base(datePart, startDate, typeof(TValue))
        {

        }

        protected DatePartFunctionExpression(DatePartsExpression datePart, DateTimeOffsetElement startDate) : base(datePart, startDate, typeof(TValue))
        {

        }

        protected DatePartFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, string alias) : base(datePart, startDate, typeof(TValue), alias)
        {

        }
        #endregion
    }
}
