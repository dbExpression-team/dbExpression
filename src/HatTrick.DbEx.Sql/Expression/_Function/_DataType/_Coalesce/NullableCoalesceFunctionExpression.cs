using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCoalesceFunctionExpression : CoalesceFunctionExpression
    {
        #region constructors
        protected NullableCoalesceFunctionExpression(params ExpressionMediator[] expressions) : base(expressions)
        {
        }
        #endregion    
    }
}
