using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectCoalesceFunctionExpression :
        CoalesceFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectCoalesceFunctionExpression>
    {
        #region constructors
        public ObjectCoalesceFunctionExpression(IList<AnyElement> expressions) : base(expressions)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectCoalesceFunctionExpression obj)
            => obj is ObjectCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
