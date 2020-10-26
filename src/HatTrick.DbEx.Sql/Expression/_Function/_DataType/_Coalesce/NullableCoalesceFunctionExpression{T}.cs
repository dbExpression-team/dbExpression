using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCoalesceFunctionExpression<TValue> : NullableCoalesceFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableCoalesceFunctionExpression(IEnumerable<ExpressionMediator<TValue>> expressions) : base(expressions)
        {
        }
        #endregion
    }
}
