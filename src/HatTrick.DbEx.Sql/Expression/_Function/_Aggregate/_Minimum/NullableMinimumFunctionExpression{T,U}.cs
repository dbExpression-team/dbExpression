using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMinimumFunctionExpression<TValue, TNullableValue> : MinimumFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableMinimumFunctionExpression(IExpressionElement expression)
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
