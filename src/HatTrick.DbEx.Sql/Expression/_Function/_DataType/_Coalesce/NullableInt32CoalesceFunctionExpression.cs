using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<int>,
        IEquatable<NullableInt32CoalesceFunctionExpression>
    {
        #region constructors
        public NullableInt32CoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableInt32CoalesceFunctionExpression), expressions)
        {
        }

        public NullableInt32CoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableInt32CoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32CoalesceFunctionExpression obj)
            => obj is NullableInt32CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
