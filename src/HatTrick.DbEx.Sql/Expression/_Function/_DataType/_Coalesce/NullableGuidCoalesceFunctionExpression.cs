using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<Guid>,
        IEquatable<NullableGuidCoalesceFunctionExpression>
    {
        #region constructors
        public NullableGuidCoalesceFunctionExpression(params NullableExpressionMediator<Guid>[] expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableGuidCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableGuidCoalesceFunctionExpression obj)
            => obj is NullableGuidCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
