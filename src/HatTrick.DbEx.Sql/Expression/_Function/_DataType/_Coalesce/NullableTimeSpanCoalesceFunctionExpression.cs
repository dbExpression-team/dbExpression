using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<TimeSpan,TimeSpan?>,
        NullTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanCoalesceFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanCoalesceFunctionExpression(IList<AnyTimeSpanElement> expressions) 
            : base(expressions)
        {

        }

        public NullableTimeSpanCoalesceFunctionExpression(IList<AnyTimeSpanElement> expressions, TimeSpanElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableTimeSpanCoalesceFunctionExpression(IList<AnyTimeSpanElement> expressions, NullTimeSpanElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableTimeSpanCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullTimeSpanElement As(string alias)
            => new NullableTimeSpanCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanCoalesceFunctionExpression obj)
            => obj is NullableTimeSpanCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
