using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleCoalesceFunctionExpression :
        CoalesceFunctionExpression<float>,
        IEquatable<SingleCoalesceFunctionExpression>
    {
        #region constructors
        public SingleCoalesceFunctionExpression(IList<NullableExpressionMediator<float>> expressions, ExpressionMediator<float> notNull) : base(expressions, notNull)
        {
        }
        #endregion

        #region as
        public new SingleCoalesceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
