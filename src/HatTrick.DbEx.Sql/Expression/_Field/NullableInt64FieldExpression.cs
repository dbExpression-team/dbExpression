using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt64FieldExpression : 
        NullableFieldExpression<long>,
        IEquatable<NullableInt64FieldExpression>
    {
        #region constructors
        protected NullableInt64FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected NullableInt64FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableInt64FieldExpression obj)
            => obj is NullableInt64FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
