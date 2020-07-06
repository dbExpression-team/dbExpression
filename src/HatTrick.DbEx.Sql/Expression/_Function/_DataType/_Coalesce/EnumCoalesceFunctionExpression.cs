using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumCoalesceFunctionExpression<TEnum> :
        CoalesceFunctionExpression<TEnum>,
        IEnumExpressionMediator<TEnum>,
        IEquatable<EnumCoalesceFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumCoalesceFunctionExpression(IList<NullableExpressionMediator<TEnum>> expressions, ExpressionMediator<TEnum> notNull) : base(expressions, notNull)
        {
        }
        #endregion

        #region as
        public new EnumCoalesceFunctionExpression<TEnum> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(EnumCoalesceFunctionExpression<TEnum> obj)
            => obj is EnumCoalesceFunctionExpression<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is EnumCoalesceFunctionExpression<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
