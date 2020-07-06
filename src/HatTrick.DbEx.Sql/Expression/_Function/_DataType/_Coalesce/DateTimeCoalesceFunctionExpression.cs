using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeCoalesceFunctionExpression :
        CoalesceFunctionExpression<DateTime>,
        IEquatable<DateTimeCoalesceFunctionExpression>
    {
        #region constructors
        public DateTimeCoalesceFunctionExpression(IList<NullableExpressionMediator<DateTime>> expressions, ExpressionMediator<DateTime> notNull) : base(expressions, notNull)
        {
        }
        #endregion

        #region as
        public new DateTimeCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeCoalesceFunctionExpression obj)
            => obj is DateTimeCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
