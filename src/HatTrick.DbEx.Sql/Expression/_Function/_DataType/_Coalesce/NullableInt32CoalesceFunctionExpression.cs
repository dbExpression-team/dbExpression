using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<int>,
        IEquatable<NullableInt32CoalesceFunctionExpression>
    {
        #region constructors
        public NullableInt32CoalesceFunctionExpression(IList<ExpressionMediator<int>> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableInt32CoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32CoalesceFunctionExpression obj)
            => obj is NullableInt32CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
