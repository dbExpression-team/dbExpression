using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringCoalesceFunctionExpression :
        CoalesceFunctionExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringCoalesceFunctionExpression>
    {
        #region constructors
        public StringCoalesceFunctionExpression(IList<AnyStringElement> expressions) : base(expressions)
        {

        }

        protected StringCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringCoalesceFunctionExpression(base.Expression, alias);
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
