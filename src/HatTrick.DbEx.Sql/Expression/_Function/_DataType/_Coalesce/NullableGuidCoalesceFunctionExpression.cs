using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<Guid,Guid?>,
        NullableGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidCoalesceFunctionExpression>
    {
        #region constructors
        public NullableGuidCoalesceFunctionExpression(IList<AnyGuidElement> expressions) 
            : base(expressions)
        {

        }

        public NullableGuidCoalesceFunctionExpression(IList<AnyGuidElement> expressions, GuidElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableGuidCoalesceFunctionExpression(IList<AnyGuidElement> expressions, NullableGuidElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }
        #endregion

        #region as
        public NullableGuidElement As(string alias)
            => new NullableGuidSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidCoalesceFunctionExpression obj)
            => obj is NullableGuidCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
