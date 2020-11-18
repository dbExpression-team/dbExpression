using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64CoalesceFunctionExpression :
        CoalesceFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64CoalesceFunctionExpression>
    {
        #region constructors
        public Int64CoalesceFunctionExpression(IList<AnyInt64Element> expressions) : base(expressions)
        {

        }

        protected Int64CoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
            => new Int64CoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(Int64CoalesceFunctionExpression obj)
            => obj is Int64CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
