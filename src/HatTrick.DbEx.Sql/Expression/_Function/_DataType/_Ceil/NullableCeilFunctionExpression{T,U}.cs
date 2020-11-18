using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCeilFunctionExpression<TValue, TNullableValue> : CeilingFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableCeilFunctionExpression(IExpressionElement expression)
            : base(expression, typeof(TNullableValue))
        {

        }

        protected NullableCeilFunctionExpression(IExpressionElement expression, string alias)
            : base(expression, typeof(TNullableValue), alias)
        {

        }
        #endregion
    }
}
