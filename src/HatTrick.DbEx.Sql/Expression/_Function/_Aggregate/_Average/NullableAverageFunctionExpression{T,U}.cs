using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableAverageFunctionExpression<TValue,TNullableValue> : AverageFunctionExpression,
        IExpressionElement<TValue,TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableAverageFunctionExpression(IExpressionElement expression, bool isDistinct) 
            : base(expression, typeof(TNullableValue), isDistinct)
        {

        }

        protected NullableAverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, typeof(TNullableValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
