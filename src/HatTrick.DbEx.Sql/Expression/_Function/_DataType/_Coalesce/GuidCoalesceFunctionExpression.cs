using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidCoalesceFunctionExpression :
        CoalesceFunctionExpression<Guid>,
        IEquatable<GuidCoalesceFunctionExpression>
    {
        #region constructors
        public GuidCoalesceFunctionExpression(IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeof(GuidCoalesceFunctionExpression), expressions, notNull)
        {
        }

        public GuidCoalesceFunctionExpression(Type typeOverride, IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeOverride, expressions, notNull)
        {
        }
        #endregion

        #region as
        public new GuidCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(GuidCoalesceFunctionExpression obj)
            => obj is GuidCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
