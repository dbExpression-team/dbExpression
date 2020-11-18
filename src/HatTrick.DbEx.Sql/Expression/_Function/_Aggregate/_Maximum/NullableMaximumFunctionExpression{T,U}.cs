using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMaximumFunctionExpression<TValue,TNullableValue> : MaximumFunctionExpression,
        IExpressionElement<TValue,TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableMaximumFunctionExpression(IExpressionElement expression, bool isDistinct)
            : base(expression, typeof(TNullableValue), isDistinct, null)
        {

        }

        protected NullableMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, typeof(TNullableValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
