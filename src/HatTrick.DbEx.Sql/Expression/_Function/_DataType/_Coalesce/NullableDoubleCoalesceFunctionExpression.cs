using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDoubleCoalesceFunctionExpression(IList<AnyDoubleElement> expressions) 
            : base(expressions)
        {

        }

        public NullableDoubleCoalesceFunctionExpression(IList<AnyDoubleElement> expressions, DoubleElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableDoubleCoalesceFunctionExpression(IList<AnyDoubleElement> expressions, NullDoubleElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableDoubleCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleCoalesceFunctionExpression obj)
            => obj is NullableDoubleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
