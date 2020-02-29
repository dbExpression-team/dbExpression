using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<decimal>,
        IEquatable<NullableDecimalCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDecimalCoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableDecimalCoalesceFunctionExpression), expressions)
        {
        }

        public NullableDecimalCoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableDecimalCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalCoalesceFunctionExpression obj)
            => obj is NullableDecimalCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
