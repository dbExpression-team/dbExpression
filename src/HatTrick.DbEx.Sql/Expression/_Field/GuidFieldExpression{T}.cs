using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidFieldExpression<TEntity> : 
        GuidFieldExpression,
        IEquatable<GuidFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public GuidFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private GuidFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new GuidFieldExpression<TEntity> As(string alias)
            => new GuidFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(GuidFieldExpression<TEntity> obj)
            => obj is GuidFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
