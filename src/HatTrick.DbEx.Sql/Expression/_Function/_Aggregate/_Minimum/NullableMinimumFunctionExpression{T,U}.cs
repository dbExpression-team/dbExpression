using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMinimumFunctionExpression<TValue, TNullableValue> : MinimumFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableMinimumFunctionExpression(IExpressionElement expression, bool isDistinct)
            : base(expression, typeof(TNullableValue), isDistinct, null)
        {

        }

        protected NullableMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, typeof(TNullableValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
