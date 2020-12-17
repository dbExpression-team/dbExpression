using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetCoalesceFunctionExpression :
        CoalesceFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetCoalesceFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetCoalesceFunctionExpression(IEnumerable<AnyDateTimeOffsetElement> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
            => new DateTimeOffsetSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetCoalesceFunctionExpression obj)
            => obj is DateTimeOffsetCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
