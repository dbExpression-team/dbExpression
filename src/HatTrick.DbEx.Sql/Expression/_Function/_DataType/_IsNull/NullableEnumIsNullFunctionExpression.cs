using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumIsNullFunctionExpression<TEnum> :
        NullableIsNullFunctionExpression<TEnum>,
        IEquatable<NullableEnumIsNullFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public NullableEnumIsNullFunctionExpression(EnumExpressionMediator<TEnum> expression, EnumExpressionMediator<TEnum> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableEnumIsNullFunctionExpression<TEnum> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableEnumIsNullFunctionExpression<TEnum> obj)
            => obj is NullableEnumIsNullFunctionExpression<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableEnumIsNullFunctionExpression<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
