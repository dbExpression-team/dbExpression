using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFieldExpression<TEntity> : 
        NullableByteFieldExpression,
        IEquatable<NullableByteFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private NullableByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableByteFieldExpression<TEntity> As(string alias)
            => new NullableByteFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteFieldExpression<TEntity> obj)
            => obj is NullableByteFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
