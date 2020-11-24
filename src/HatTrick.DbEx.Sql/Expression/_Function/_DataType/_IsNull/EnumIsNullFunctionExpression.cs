using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumIsNullFunctionExpression<TEnum> :
        IsNullFunctionExpression<TEnum>,
        EnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<EnumIsNullFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumIsNullFunctionExpression(AnyEnumElement<TEnum> expression, EnumElement<TEnum> value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public EnumElement<TEnum> As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(EnumIsNullFunctionExpression<TEnum> obj)
            => obj is EnumIsNullFunctionExpression<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is EnumIsNullFunctionExpression<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
