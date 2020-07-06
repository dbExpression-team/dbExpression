using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCoalesceFunctionExpression<TValue> : NullableCoalesceFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableCoalesceFunctionExpression(params NullableExpressionMediator<TValue>[] expressions) : base(expressions)
        {
        }
        #endregion
    }
}
