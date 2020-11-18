using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16CoalesceFunctionExpression>
    {
        #region constructors
        public NullableInt16CoalesceFunctionExpression(IList<AnyInt16Element> expressions) 
            : base(expressions)
        {

        }

        public NullableInt16CoalesceFunctionExpression(IList<AnyInt16Element> expressions, Int16Element termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableInt16CoalesceFunctionExpression(IList<AnyInt16Element> expressions, NullInt16Element termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableInt16CoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16CoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16CoalesceFunctionExpression obj)
            => obj is NullableInt16CoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16CoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
