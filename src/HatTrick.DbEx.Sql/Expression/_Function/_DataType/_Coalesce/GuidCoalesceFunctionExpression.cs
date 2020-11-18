using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidCoalesceFunctionExpression :
        CoalesceFunctionExpression<Guid>,
        GuidElement,
        AnyGuidElement,
        IEquatable<GuidCoalesceFunctionExpression>
    {
        #region constructors
        public GuidCoalesceFunctionExpression(IList<AnyGuidElement> expressions) : base(expressions)
        {

        }

        protected GuidCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidCoalesceFunctionExpression(base.Expression, alias);
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
