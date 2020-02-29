using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<short>,
        IEquatable<NullableInt16CoalesceFunctionExpression>
    {
        #region constructors
        public NullableInt16CoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableInt16CoalesceFunctionExpression), expressions)
        {
        }

        public NullableInt16CoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableInt16CoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16CoalesceFunctionExpression obj)
            => obj is NullableInt16CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
