using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateAddFunctionExpression<TValue> : DateAddFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected DateAddFunctionExpression(DatePartsExpression datePart, ExpressionMediator value, ExpressionMediator<TValue> expression) : base(datePart, value, expression)
        {
        }
        #endregion
    }
}
