using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MaximumFunctionExpression<TValue> : MaximumFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected MaximumFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TValue), isDistinct)
        {

        }

        protected MaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TValue), isDistinct, alias)
        {

        }
        #endregion
    }
}


