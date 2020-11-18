using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableVarianceFunctionExpression<TValue, TNullableValue> : VarianceFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableVarianceFunctionExpression(IExpressionElement expression, bool isDistinct)
            : base(expression, typeof(TNullableValue), isDistinct)
        {

        }

        protected NullableVarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, typeof(TNullableValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
