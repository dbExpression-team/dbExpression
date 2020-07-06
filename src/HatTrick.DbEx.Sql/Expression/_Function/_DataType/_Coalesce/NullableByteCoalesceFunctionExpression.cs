using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<byte>,
        IEquatable<NullableByteCoalesceFunctionExpression>
    {
        #region constructors
        public NullableByteCoalesceFunctionExpression(params NullableExpressionMediator<byte>[] expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableByteCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteCoalesceFunctionExpression obj)
            => obj is NullableByteCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
