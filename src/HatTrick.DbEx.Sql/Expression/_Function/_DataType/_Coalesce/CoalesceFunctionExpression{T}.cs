using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression<TValue> : CoalesceFunctionExpression
    {
        #region constructors
        protected CoalesceFunctionExpression(IEnumerable<ExpressionMediator<TValue>> expressions) : base(expressions)
        {
        }
        #endregion
    }
}
