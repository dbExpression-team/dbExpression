using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<bool>,
        IEquatable<NullableBooleanCoalesceFunctionExpression>
    {
        #region constructors
        public NullableBooleanCoalesceFunctionExpression(params ExpressionContainer[] expressions) : base(typeof(NullableBooleanCoalesceFunctionExpression), expressions)
        {
        }

        public NullableBooleanCoalesceFunctionExpression(Type typeOverride, params ExpressionContainer[] expressions) : base(typeOverride, expressions)
        {
        }
        #endregion

        #region as
        public new NullableBooleanCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableBooleanCoalesceFunctionExpression obj)
            => obj is NullableBooleanCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
