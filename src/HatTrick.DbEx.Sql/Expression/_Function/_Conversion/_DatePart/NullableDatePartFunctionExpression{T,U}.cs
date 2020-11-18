using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDatePartFunctionExpression<TValue, TNullableValue> : DatePartFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableDatePartFunctionExpression(DatePartsExpression datePart, NullDateTimeElement expression) : base(datePart, expression, typeof(TNullableValue))
        {

        }

        protected NullableDatePartFunctionExpression(DatePartsExpression datePart, NullDateTimeOffsetElement expression) : base(datePart, expression, typeof(TNullableValue))
        {

        }

        protected NullableDatePartFunctionExpression(DatePartsExpression datePart, IExpressionElement expression, string alias) : base(datePart, expression, typeof(TNullableValue), alias)
        {

        }
        #endregion
    }
}
