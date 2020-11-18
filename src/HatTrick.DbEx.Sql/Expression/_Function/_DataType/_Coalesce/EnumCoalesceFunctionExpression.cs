using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumCoalesceFunctionExpression<TEnum> :
        CoalesceFunctionExpression<TEnum>,
        EnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<EnumCoalesceFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumCoalesceFunctionExpression(IList<AnyEnumElement<TEnum>> expressions) : base(expressions)
        {

        }

        protected EnumCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public EnumElement<TEnum> As(string alias)
            => new EnumCoalesceFunctionExpression<TEnum>(base.Expression, alias);
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
