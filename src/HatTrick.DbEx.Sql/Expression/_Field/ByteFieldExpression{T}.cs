using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteFieldExpression<TEntity> : 
        ByteFieldExpression,
        IEquatable<ByteFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public ByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private ByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new ByteFieldExpression<TEntity> As(string alias)
            => new ByteFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(ByteFieldExpression<TEntity> obj)
            => obj is ByteFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
