using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidFieldExpression<TEntity> : 
        NullableGuidFieldExpression,
        IEquatable<NullableGuidFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableGuidFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private NullableGuidFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableGuidFieldExpression<TEntity> As(string alias)
            => new NullableGuidFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidFieldExpression<TEntity> obj)
            => obj is NullableGuidFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
