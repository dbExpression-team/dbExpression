using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDatePartFunctionExpression<TValue> : NullableDatePartFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableDatePartFunctionExpression(ExpressionContainer datePart, ExpressionContainer expression) : base(datePart, expression)
        {
        }
        #endregion
    }
}
