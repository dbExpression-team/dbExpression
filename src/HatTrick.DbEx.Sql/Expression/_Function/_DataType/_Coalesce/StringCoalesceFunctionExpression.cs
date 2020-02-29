using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringCoalesceFunctionExpression :
        CoalesceFunctionExpression<string>,
        IEquatable<StringCoalesceFunctionExpression>
    {
        #region constructors
        public StringCoalesceFunctionExpression(IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeof(StringCoalesceFunctionExpression), expressions, notNull)
        {
        }

        public StringCoalesceFunctionExpression(Type typeOverride, IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeOverride, expressions, notNull)
        {
        }
        #endregion

        #region as
        public new StringCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(StringCoalesceFunctionExpression obj)
            => obj is StringCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
