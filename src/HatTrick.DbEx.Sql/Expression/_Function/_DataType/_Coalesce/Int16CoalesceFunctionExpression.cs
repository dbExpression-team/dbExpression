using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16CoalesceFunctionExpression :
        CoalesceFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16CoalesceFunctionExpression>
    {
        #region constructors
        public Int16CoalesceFunctionExpression(IList<AnyInt16Element> expressions) : base(expressions)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16SelectExpression(this).As(alias);
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
