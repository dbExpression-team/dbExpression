using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<float>,
        IEquatable<NullableSingleCoalesceFunctionExpression>
    {
        #region constructors
        public NullableSingleCoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableSingleCoalesceFunctionExpression), expressions)
        {
        }

        public NullableSingleCoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableSingleCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleCoalesceFunctionExpression obj)
            => obj is NullableSingleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
