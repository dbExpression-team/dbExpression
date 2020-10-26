using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64CoalesceFunctionExpression :
        CoalesceFunctionExpression<long>,
        IEquatable<Int64CoalesceFunctionExpression>
    {
        #region constructors
        public Int64CoalesceFunctionExpression(IList<ExpressionMediator<long>> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new Int64CoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64CoalesceFunctionExpression obj)
            => obj is Int64CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
