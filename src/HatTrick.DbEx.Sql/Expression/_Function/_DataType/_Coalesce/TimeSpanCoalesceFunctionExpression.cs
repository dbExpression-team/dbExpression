using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanCoalesceFunctionExpression :
        CoalesceFunctionExpression<TimeSpan>,
        IEquatable<TimeSpanCoalesceFunctionExpression>
    {
        #region constructors
        public TimeSpanCoalesceFunctionExpression(IList<ExpressionMediator<TimeSpan>> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new TimeSpanCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(TimeSpanCoalesceFunctionExpression obj)
            => obj is TimeSpanCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
