using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
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

        public NullableDecimalCoalesceFunctionExpression(IList<AnyDecimalElement> expressions, NullableDecimalElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }
        #endregion

        #region as
        public NullableDecimalElement As(string alias)
        {
            Alias = alias;
            return this;
        }
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
