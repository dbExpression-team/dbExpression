using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumCoalesceFunctionExpression<TEnum> :
        NullableCoalesceFunctionExpression<TEnum>,
        IEquatable<NullableEnumCoalesceFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public NullableEnumCoalesceFunctionExpression(IEnumerable<EnumExpressionMediator<TEnum>> expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new NullableEnumCoalesceFunctionExpression<TEnum> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableEnumCoalesceFunctionExpression<TEnum> obj)
            => obj is NullableEnumCoalesceFunctionExpression<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableEnumCoalesceFunctionExpression<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
