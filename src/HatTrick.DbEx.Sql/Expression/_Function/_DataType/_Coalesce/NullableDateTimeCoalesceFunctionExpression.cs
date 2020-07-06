using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<DateTime>,
        IEquatable<NullableDateTimeCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDateTimeCoalesceFunctionExpression(params NullableExpressionMediator<DateTime>[] expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeCoalesceFunctionExpression obj)
            => obj is NullableDateTimeCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
