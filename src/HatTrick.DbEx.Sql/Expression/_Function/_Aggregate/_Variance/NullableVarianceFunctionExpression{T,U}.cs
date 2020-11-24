using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableVarianceFunctionExpression<TValue, TNullableValue> : VarianceFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableVarianceFunctionExpression(IExpressionElement expression)
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
