using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumCoalesceFunctionExpression<TEnum> :
        NullableCoalesceFunctionExpression<TEnum,TEnum?>,
        NullableEnumElement<TEnum>,
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

        public NullableEnumCoalesceFunctionExpression(IList<AnyEnumElement<TEnum>> expressions, NullableEnumElement<TEnum> termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }
        #endregion

        #region as
        public NullableEnumElement<TEnum> As(string alias)
            => new NullableEnumSelectExpression<TEnum>(this).As(alias);
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
