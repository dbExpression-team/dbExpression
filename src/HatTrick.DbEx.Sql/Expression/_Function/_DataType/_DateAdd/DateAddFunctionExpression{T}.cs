using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateAddFunctionExpression<TValue> : DateAddFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected DateAddFunctionExpression(ExpressionContainer datePart, ExpressionContainer value, ExpressionContainer expression) : base(datePart, value, expression)
        {
        }
        #endregion
    }
}
