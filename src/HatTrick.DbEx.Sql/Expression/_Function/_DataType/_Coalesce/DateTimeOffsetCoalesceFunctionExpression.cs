using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetCoalesceFunctionExpression :
        CoalesceFunctionExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetCoalesceFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetCoalesceFunctionExpression(IList<NullableExpressionMediator<DateTimeOffset>> expressions, ExpressionMediator<DateTimeOffset> notNull) : base(expressions, notNull)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
