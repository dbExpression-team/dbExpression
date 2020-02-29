using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DatePartFunctionExpression<TValue> : DatePartFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected DatePartFunctionExpression(ExpressionContainer datePart, ExpressionContainer startDate) : base(datePart, startDate)
        {
        }
        #endregion
    }
}
