using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCoalesceFunctionExpression :
        CoalesceFunctionExpression<byte>,
        IEquatable<ByteCoalesceFunctionExpression>
    {
        #region constructors
        public ByteCoalesceFunctionExpression(IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeof(ByteCoalesceFunctionExpression), expressions, notNull)
        {
        }

        public ByteCoalesceFunctionExpression(Type typeOverride, IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(typeOverride, expressions, notNull)
        {
        }
        #endregion

        #region as
        public new ByteCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteCoalesceFunctionExpression obj)
            => obj is ByteCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
