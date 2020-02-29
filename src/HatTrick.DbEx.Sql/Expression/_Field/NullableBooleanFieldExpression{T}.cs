using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanFieldExpression<TEntity> : 
        NullableBooleanFieldExpression,
        IEquatable<NullableBooleanFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableBooleanFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private NullableBooleanFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableBooleanFieldExpression<TEntity> As(string alias)
            => new NullableBooleanFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableBooleanFieldExpression<TEntity> obj)
            => obj is NullableBooleanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
