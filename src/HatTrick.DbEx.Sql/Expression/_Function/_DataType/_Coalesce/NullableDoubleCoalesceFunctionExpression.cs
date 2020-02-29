using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<double>,
        IEquatable<NullableDoubleCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDoubleCoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableDoubleCoalesceFunctionExpression), expressions)
        {
        }

        public NullableDoubleCoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableDoubleCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleCoalesceFunctionExpression obj)
            => obj is NullableDoubleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
