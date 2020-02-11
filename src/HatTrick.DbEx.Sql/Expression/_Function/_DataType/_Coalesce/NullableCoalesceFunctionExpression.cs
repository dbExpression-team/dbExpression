using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCoalesceFunctionExpression : CoalesceFunctionExpression
    {
        #region constructors
        protected NullableCoalesceFunctionExpression()
        {
        }

        protected NullableCoalesceFunctionExpression(params (Type, object)[] expressions) : base(expressions)
        {
        }
        #endregion    
    }
}
