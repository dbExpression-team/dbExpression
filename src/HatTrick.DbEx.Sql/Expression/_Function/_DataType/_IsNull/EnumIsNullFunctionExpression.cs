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

        protected EnumIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public EnumElement<TEnum> As(string alias)
            => new EnumIsNullFunctionExpression<TEnum>(base.Expression, base.Value, alias);
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
