using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumCoalesceFunctionExpression<TEnum> :
        NullableCoalesceFunctionExpression<TEnum,TEnum?>,
        NullEnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<NullableEnumCoalesceFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public NullableEnumCoalesceFunctionExpression(IList<AnyEnumElement<TEnum>> expressions) 
            : base(expressions)
        {

        }

        public NullableEnumCoalesceFunctionExpression(IList<AnyEnumElement<TEnum>> expressions, EnumElement<TEnum> termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableEnumCoalesceFunctionExpression(IList<AnyEnumElement<TEnum>> expressions, NullEnumElement<TEnum> termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableEnumCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullEnumElement<TEnum> As(string alias)
            => new NullableEnumCoalesceFunctionExpression<TEnum>(base.Expression, alias);
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
