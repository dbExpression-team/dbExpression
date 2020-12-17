using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCoalesceFunctionExpression :
        CoalesceFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteCoalesceFunctionExpression>
    {
        #region constructors
        public ByteCoalesceFunctionExpression(IList<AnyByteElement> expressions) : base(expressions)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(ByteCoalesceFunctionExpression obj)
            => obj is ByteCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
