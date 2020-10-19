using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<TimeSpan>,
        IEquatable<NullableTimeSpanCoalesceFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanCoalesceFunctionExpression(params NullableExpressionMediator<TimeSpan>[] expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableTimeSpanCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanCoalesceFunctionExpression obj)
            => obj is NullableTimeSpanCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
