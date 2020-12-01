using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateAddFunctionExpression<TValue, TNullableValue> : DateAddFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableDateAddFunctionExpression(DatePartsExpression datePart, IExpressionElement value, IExpressionElement expression)
            : base(datePart, value, expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
