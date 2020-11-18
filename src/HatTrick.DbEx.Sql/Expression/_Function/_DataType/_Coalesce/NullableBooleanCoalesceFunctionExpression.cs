using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<bool,bool?>,
        NullBooleanElement,
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

        public NullableBooleanCoalesceFunctionExpression(IList<AnyBooleanElement> expressions, NullBooleanElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableBooleanCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullBooleanElement As(string alias)
            => new NullableBooleanCoalesceFunctionExpression(base.Expression, alias);
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
