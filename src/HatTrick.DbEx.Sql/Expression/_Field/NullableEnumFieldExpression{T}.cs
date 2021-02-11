using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableEnumFieldExpression<TEnum> : 
        NullableFieldExpression<TEnum,TEnum?>,
        INullableEnumExpressionMediator<TEnum>,
        NullableEnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<NullableFieldExpression<TEnum,TEnum?>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected NullableEnumFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public abstract NullableEnumElement<TEnum> As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableFieldExpression<TEnum, TEnum?> obj)
            => obj is NullableFieldExpression<TEnum, TEnum?> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableFieldExpression<TEnum, TEnum?> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
