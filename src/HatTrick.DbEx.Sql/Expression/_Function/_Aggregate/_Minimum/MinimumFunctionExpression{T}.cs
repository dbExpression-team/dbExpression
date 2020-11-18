using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MinimumFunctionExpression<TValue> : MinimumFunctionExpression,
        IExpressionElement<TValue>
         where TValue : IComparable
    {
        #region constructors
        protected MinimumFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TValue), isDistinct)
        {

        }

        protected MinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
