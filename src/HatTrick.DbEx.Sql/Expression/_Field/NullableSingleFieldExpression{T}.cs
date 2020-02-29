using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleFieldExpression<TEntity> : 
        NullableSingleFieldExpression,
        IEquatable<NullableSingleFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableSingleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private NullableSingleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableSingleFieldExpression<TEntity> As(string alias)
            => new NullableSingleFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleFieldExpression<TEntity> obj)
            => obj is NullableSingleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
