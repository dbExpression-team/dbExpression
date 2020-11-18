using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleCoalesceFunctionExpression :
        CoalesceFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleCoalesceFunctionExpression>
    {
        #region constructors
        public SingleCoalesceFunctionExpression(IList<AnySingleElement> expressions) : base(expressions)
        {

        }

        protected SingleCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(SingleCoalesceFunctionExpression obj)
            => obj is SingleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
