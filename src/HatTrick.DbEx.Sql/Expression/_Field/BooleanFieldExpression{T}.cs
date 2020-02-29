using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanFieldExpression<TEntity> : 
        BooleanFieldExpression,
        IEquatable<BooleanFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public BooleanFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private BooleanFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new BooleanFieldExpression<TEntity> As(string alias)
            => new BooleanFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(BooleanFieldExpression<TEntity> obj)
            => obj is BooleanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
