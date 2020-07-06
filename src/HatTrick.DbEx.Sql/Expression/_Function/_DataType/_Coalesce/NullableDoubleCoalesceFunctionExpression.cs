using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<double>,
        IEquatable<NullableDoubleCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDoubleCoalesceFunctionExpression(params NullableExpressionMediator<double>[] expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableDoubleCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleCoalesceFunctionExpression obj)
            => obj is NullableDoubleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
