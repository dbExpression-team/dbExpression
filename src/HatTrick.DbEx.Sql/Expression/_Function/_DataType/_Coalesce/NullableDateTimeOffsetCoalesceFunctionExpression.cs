using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetCoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableDateTimeOffsetCoalesceFunctionExpression), expressions)
        {
        }

        public NullableDateTimeOffsetCoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeOffsetCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetCoalesceFunctionExpression obj)
            => obj is NullableDateTimeOffsetCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
