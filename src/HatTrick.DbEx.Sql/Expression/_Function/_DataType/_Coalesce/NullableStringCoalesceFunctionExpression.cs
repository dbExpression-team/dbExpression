using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<string>,
        IEquatable<NullableStringCoalesceFunctionExpression>
    {
        #region constructors
        public NullableStringCoalesceFunctionExpression(IList<ExpressionMediator<string>> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableStringCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableStringCoalesceFunctionExpression obj)
            => obj is NullableStringCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
