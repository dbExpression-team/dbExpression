using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanCoalesceFunctionExpression :
        CoalesceFunctionExpression<bool>,
        IEquatable<BooleanCoalesceFunctionExpression>
    {
        #region constructors
        public BooleanCoalesceFunctionExpression(IList<ExpressionMediator<bool>> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new BooleanCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(BooleanCoalesceFunctionExpression obj)
            => obj is BooleanCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
