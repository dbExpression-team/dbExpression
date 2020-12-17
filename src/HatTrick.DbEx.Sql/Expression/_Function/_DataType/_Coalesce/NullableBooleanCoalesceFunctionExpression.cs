using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<bool,bool?>,
        NullableBooleanElement,
        AnyBooleanElement,
        IEquatable<NullableBooleanCoalesceFunctionExpression>
    {
        #region constructors
        public NullableBooleanCoalesceFunctionExpression(IList<AnyBooleanElement> expressions) 
            : base(expressions)
        {

        }

        public NullableBooleanCoalesceFunctionExpression(IList<AnyBooleanElement> expressions, BooleanElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableBooleanCoalesceFunctionExpression(IList<AnyBooleanElement> expressions, NullableBooleanElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }
        #endregion

        #region as
        public NullableBooleanElement As(string alias)
            => new NullableBooleanSelectExpression(this).As(alias);
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
