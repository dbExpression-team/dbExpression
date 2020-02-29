using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16CoalesceFunctionExpression :
        CoalesceFunctionExpression<short>,
        IEquatable<Int16CoalesceFunctionExpression>
    {
        #region constructors
        public Int16CoalesceFunctionExpression(IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeof(Int16CoalesceFunctionExpression), expressions, notNull)
        {
        }

        public Int16CoalesceFunctionExpression(Type typeOverride, IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeOverride, expressions, notNull)
        {
        }
        #endregion

        #region as
        public new Int16CoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16CoalesceFunctionExpression obj)
            => obj is Int16CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
