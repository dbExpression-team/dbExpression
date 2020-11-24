using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanCoalesceFunctionExpression :
        CoalesceFunctionExpression<TimeSpan>,
        TimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<TimeSpanCoalesceFunctionExpression>
    {
        #region constructors
        public TimeSpanCoalesceFunctionExpression(IList<AnyTimeSpanElement> expressions) : base(expressions)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
        {
            Alias = alias;
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
