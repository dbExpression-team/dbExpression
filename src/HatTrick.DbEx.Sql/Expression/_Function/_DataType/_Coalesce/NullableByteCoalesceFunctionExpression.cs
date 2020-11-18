using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<byte,byte?>,
        NullByteElement,
        AnyByteElement,
        IEquatable<NullableByteCoalesceFunctionExpression>
    {
        #region constructors
        public NullableByteCoalesceFunctionExpression(IList<AnyByteElement> expressions) 
            : base(expressions)
        {

        }

        public NullableByteCoalesceFunctionExpression(IList<AnyByteElement> expressions, ByteElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableByteCoalesceFunctionExpression(IList<AnyByteElement> expressions, NullByteElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableByteCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullByteElement As(string alias)
            => new NullableByteCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteCoalesceFunctionExpression obj)
            => obj is NullableByteCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
