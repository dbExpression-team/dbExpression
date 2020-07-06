using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MinimumFunctionExpression<TValue> : MinimumFunctionExpression
         where TValue : IComparable
    {
        #region constructors
        protected MinimumFunctionExpression(ExpressionMediator<TValue> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
