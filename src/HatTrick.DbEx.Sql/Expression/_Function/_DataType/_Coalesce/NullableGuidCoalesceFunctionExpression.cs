using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<Guid,Guid?>,
        NullGuidElement,
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

        public NullableGuidCoalesceFunctionExpression(IList<AnyGuidElement> expressions, NullGuidElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableGuidCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullGuidElement As(string alias)
            => new NullableGuidCoalesceFunctionExpression(base.Expression, alias);
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
