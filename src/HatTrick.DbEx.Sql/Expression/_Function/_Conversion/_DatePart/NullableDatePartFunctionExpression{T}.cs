using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDatePartFunctionExpression<TValue> : NullableDatePartFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableDatePartFunctionExpression(ExpressionContainer datePart, NullableExpressionMediator<DateTime> expression) : base(datePart, expression)
        {

        }
            
        protected NullableDatePartFunctionExpression(ExpressionContainer datePart, NullableExpressionMediator<DateTimeOffset> expression) : base(datePart, expression)
        {

        }
        #endregion
    }
}
