using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeCoalesceFunctionExpression :
        CoalesceFunctionExpression<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<DateTimeCoalesceFunctionExpression>
    {
        #region constructors
        public DateTimeCoalesceFunctionExpression(IList<AnyDateTimeElement> expressions) : base(expressions)
        {

        }

        protected DateTimeCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeCoalesceFunctionExpression(base.Expression, alias);
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
