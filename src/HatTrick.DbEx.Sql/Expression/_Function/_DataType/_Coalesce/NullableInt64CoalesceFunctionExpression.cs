using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64CoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64CoalesceFunctionExpression>
    {
        #region constructors
        public NullableInt64CoalesceFunctionExpression(IList<AnyInt64Element> expressions) 
            : base(expressions)
        {

        }

        public NullableInt64CoalesceFunctionExpression(IList<AnyInt64Element> expressions, Int64Element termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableInt64CoalesceFunctionExpression(IList<AnyInt64Element> expressions, NullableInt64Element termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64CoalesceFunctionExpression obj)
            => obj is NullableInt64CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
