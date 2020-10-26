using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCoalesceFunctionExpression : CoalesceFunctionExpression
    {
        #region constructors
        protected NullableCoalesceFunctionExpression(IEnumerable<ExpressionMediator> expressions) : base(expressions)
        {
        }
        #endregion    
    }
}
