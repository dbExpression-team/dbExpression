using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression<TValue> : CoalesceFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected CoalesceFunctionExpression(IEnumerable<IExpressionElement> expressions) : base(expressions, typeof(TValue))
        {

        }
        #endregion
    }
}
