using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleCoalesceFunctionExpression :
        CoalesceFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleCoalesceFunctionExpression>
    {
        #region constructors
        public DoubleCoalesceFunctionExpression(IList<AnyDoubleElement> expressions) : base(expressions)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleCoalesceFunctionExpression obj)
            => obj is DoubleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
