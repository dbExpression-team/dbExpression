using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumIsNullFunctionExpression<TEnum> :
        NullableIsNullFunctionExpression<TEnum,TEnum?>,
        NullEnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<NullableEnumIsNullFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public NullableEnumIsNullFunctionExpression(AnyEnumElement<TEnum> expression, NullEnumElement<TEnum> value)
            : base(expression, value)
        {

        }

        protected NullableEnumIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullEnumElement<TEnum> As(string alias)
            => new NullableEnumIsNullFunctionExpression<TEnum>(base.Expression, base.Value, alias);
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
