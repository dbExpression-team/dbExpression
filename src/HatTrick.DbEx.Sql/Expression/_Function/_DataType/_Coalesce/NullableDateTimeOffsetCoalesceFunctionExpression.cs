using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetCoalesceFunctionExpression(IList<ExpressionMediator<DateTimeOffset>> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeOffsetCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetCoalesceFunctionExpression obj)
            => obj is NullableDateTimeOffsetCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
