using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32CoalesceFunctionExpression>
    {
        #region constructors
        public NullableInt32CoalesceFunctionExpression(IList<AnyInt32Element> expressions) 
        : base(expressions)
        {

        }

        public NullableInt32CoalesceFunctionExpression(IList<AnyInt32Element> expressions, Int32Element termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableInt32CoalesceFunctionExpression(IList<AnyInt32Element> expressions, NullableInt32Element termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
            => new NullableInt32SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32CoalesceFunctionExpression obj)
            => obj is NullableInt32CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
