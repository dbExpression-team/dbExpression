using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMaximumFunctionExpression<TValue,TNullableValue> : MaximumFunctionExpression,
        IExpressionElement<TValue,TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableMaximumFunctionExpression(IExpressionElement expression)
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
