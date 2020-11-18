using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<string,string>,
        NullStringElement,
        AnyStringElement,
        IEquatable<NullableStringCoalesceFunctionExpression>
    {
        #region constructors
        public NullableStringCoalesceFunctionExpression(IList<AnyStringElement> expressions) 
            : base(expressions)
        {

        }

        public NullableStringCoalesceFunctionExpression(IList<AnyStringElement> expressions, StringElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableStringCoalesceFunctionExpression(IList<AnyStringElement> expressions, NullStringElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableStringCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullStringElement As(string alias)
            => new NullableStringCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableStringCoalesceFunctionExpression obj)
            => obj is NullableStringCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
