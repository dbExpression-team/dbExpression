using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64FieldExpression<TEntity> : 
        NullableInt64FieldExpression,
        IEquatable<NullableInt64FieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableInt64FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private NullableInt64FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableInt64FieldExpression<TEntity> As(string alias)
            => new NullableInt64FieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64FieldExpression<TEntity> obj)
            => obj is NullableInt64FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
