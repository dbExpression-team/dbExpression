using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateAddFunctionExpression<TValue> : NullableDateAddFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableDateAddFunctionExpression(ExpressionContainer datePart, ExpressionContainer value, ExpressionContainer expression) : base(datePart, value, expression)
        {
        }
        #endregion
    }
}
