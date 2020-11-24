using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDatePartFunctionExpression<TValue, TNullableValue> : DatePartFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableDatePartFunctionExpression(DatePartsExpression datePart, NullableDateTimeElement expression) : base(datePart, expression, typeof(TNullableValue))
        {

        }

        protected NullableDatePartFunctionExpression(DatePartsExpression datePart, NullableDateTimeOffsetElement expression) : base(datePart, expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
