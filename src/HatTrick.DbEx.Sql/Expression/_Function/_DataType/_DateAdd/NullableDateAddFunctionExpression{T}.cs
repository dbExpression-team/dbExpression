using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateAddFunctionExpression<TValue> : NullableDateAddFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableDateAddFunctionExpression(DatePartsExpression datePart, NullableExpressionMediator<int> value, ExpressionMediator<TValue> expression) : base(datePart, value, expression)
        {
        }

        protected NullableDateAddFunctionExpression(DatePartsExpression datePart, ExpressionMediator<int> value, ExpressionMediator<TValue> expression) : base(datePart, value, expression)
        {
        }
        #endregion
    }
}
