using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDecimalCoalesceFunctionExpression(IList<AnyDecimalElement> expressions) 
            : base(expressions)
        {

        }

        public NullableDecimalCoalesceFunctionExpression(IList<AnyDecimalElement> expressions, DecimalElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableDecimalCoalesceFunctionExpression(IList<AnyDecimalElement> expressions, NullDecimalElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableDecimalCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalCoalesceFunctionExpression obj)
            => obj is NullableDecimalCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
