using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableEnumFieldExpression<TEnum> : 
        NullableFieldExpression<TEnum>,
        INullableEnumExpressionMediator<TEnum>,
        IEquatable<NullableFieldExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected NullableEnumFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {
        }

        protected NullableEnumFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region as
        public new NullableFieldExpression<TEnum> As(string alias)
        {
            base.As(alias);
            return this;
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
