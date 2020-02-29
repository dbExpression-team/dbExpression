using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EnumFieldExpression<TEnum> : FieldExpression<TEnum>,
        IEnumExpressionMediator<TEnum>,
        IEquatable<EnumFieldExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected EnumFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {
        }

        protected EnumFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
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
