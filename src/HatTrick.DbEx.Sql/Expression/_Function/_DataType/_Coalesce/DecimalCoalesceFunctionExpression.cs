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

        protected DecimalCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalCoalesceFunctionExpression(base.Expression, alias);
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
