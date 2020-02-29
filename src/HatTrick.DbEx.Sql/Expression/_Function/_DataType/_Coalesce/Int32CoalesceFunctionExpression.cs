using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CoalesceFunctionExpression :
        CoalesceFunctionExpression<int>,
        IEquatable<Int32CoalesceFunctionExpression>
    {
        #region constructors
        public Int32CoalesceFunctionExpression(IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeof(Int32CoalesceFunctionExpression), expressions, notNull)
        {
        }

        public Int32CoalesceFunctionExpression(Type typeOverride, IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeOverride, expressions, notNull)
        {
        }
        #endregion

        #region as
        public new Int32CoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32CoalesceFunctionExpression obj)
            => obj is Int32CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
