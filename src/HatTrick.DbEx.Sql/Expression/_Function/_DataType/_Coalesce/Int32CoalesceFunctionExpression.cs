using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CoalesceFunctionExpression :
        CoalesceFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32CoalesceFunctionExpression>
    {
        #region constructors
        public Int32CoalesceFunctionExpression(IList<AnyInt32Element> expressions) : base(expressions)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int32CoalesceFunctionExpression obj)
            => obj is Int32CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
