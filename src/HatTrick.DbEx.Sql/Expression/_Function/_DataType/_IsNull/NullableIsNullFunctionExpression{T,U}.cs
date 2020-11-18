using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableIsNullFunctionExpression<TValue, TNullableValue> : IsNullFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value)
            : base(expression, typeof(TNullableValue), value)
        {

        }

        protected NullableIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, typeof(TNullableValue), value, alias)
        {

        }
        #endregion
    }
}
