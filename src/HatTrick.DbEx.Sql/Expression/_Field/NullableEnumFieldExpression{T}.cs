using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableEnumFieldExpression<TEnum> : 
        NullableFieldExpression<TEnum>,
        INullableEnumExpressionMediator<TEnum>,
        IEquatable<NullableFieldExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected NullableEnumFieldExpression(string identifier, Type declaredType, EntityExpression entity) : base(identifier, declaredType, entity)
        {
        }

        protected NullableEnumFieldExpression(string identifier, Type declaredType, EntityExpression entity, string alias) : base(identifier, declaredType, entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableFieldExpression<TEnum> obj)
            => obj is NullableFieldExpression<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableFieldExpression<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
