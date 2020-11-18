using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class AverageFunctionExpression<TValue> : AverageFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected AverageFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TValue), isDistinct)
        {

        }

        protected AverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
