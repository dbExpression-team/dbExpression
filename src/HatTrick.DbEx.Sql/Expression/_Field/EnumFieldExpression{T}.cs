using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EnumFieldExpression<TEnum> : FieldExpression<TEnum>,
        EnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<EnumFieldExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected EnumFieldExpression(string identifier, string name, Type declaredType, EntityExpression entity) : base(identifier, name, declaredType, entity)
        {

        }
        #endregion

        #region as
        public abstract EnumElement<TEnum> As(string alias);
        #endregion

        #region equals
        public bool Equals(EnumFieldExpression<TEnum> obj)
            => obj is EnumFieldExpression<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is EnumFieldExpression<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
