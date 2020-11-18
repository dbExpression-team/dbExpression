using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableEnumFieldExpression<TEnum> : 
        NullableFieldExpression<TEnum,TEnum?>,
        INullableEnumExpressionMediator<TEnum>,
        NullEnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<NullableFieldExpression<TEnum,TEnum?>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected NullableEnumFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {
        }

        protected NullableEnumFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullEnumElement<TEnum> As(string alias);
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
