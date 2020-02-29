using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleCoalesceFunctionExpression :
        CoalesceFunctionExpression<double>,
        IEquatable<DoubleCoalesceFunctionExpression>
    {
        #region constructors
        public DoubleCoalesceFunctionExpression(IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeof(DoubleCoalesceFunctionExpression), expressions, notNull)
        {
        }

        public DoubleCoalesceFunctionExpression(Type typeOverride, IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeOverride, expressions, notNull)
        {
        }
        #endregion

        #region as
        public new DoubleCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleCoalesceFunctionExpression obj)
            => obj is DoubleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
