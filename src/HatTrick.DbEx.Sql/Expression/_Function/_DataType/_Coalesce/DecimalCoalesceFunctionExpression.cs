using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalCoalesceFunctionExpression :
        CoalesceFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalCoalesceFunctionExpression>
    {
        #region constructors
        public DecimalCoalesceFunctionExpression(IList<AnyDecimalElement> expressions) : base(expressions)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalCoalesceFunctionExpression obj)
            => obj is DecimalCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
