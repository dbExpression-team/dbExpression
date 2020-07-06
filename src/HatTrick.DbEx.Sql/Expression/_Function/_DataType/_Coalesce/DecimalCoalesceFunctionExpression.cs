using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalCoalesceFunctionExpression :
        CoalesceFunctionExpression<decimal>,
        IEquatable<DecimalCoalesceFunctionExpression>
    {
        #region constructors
        public DecimalCoalesceFunctionExpression(IList<NullableExpressionMediator<decimal>> expressions, ExpressionMediator<decimal> notNull) : base(expressions, notNull)
        {
        }
        #endregion

        #region as
        public new DecimalCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
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
