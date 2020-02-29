using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64CoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<long>,
        IEquatable<NullableInt64CoalesceFunctionExpression>
    {
        #region constructors
        public NullableInt64CoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableInt64CoalesceFunctionExpression), expressions)
        {
        }

        public NullableInt64CoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableInt64CoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64CoalesceFunctionExpression obj)
            => obj is NullableInt64CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
