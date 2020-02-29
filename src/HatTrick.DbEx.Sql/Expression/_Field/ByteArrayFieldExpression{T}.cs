using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : ByteArrayFieldExpression
        where TEntity : IDbEntity,
        IEquatable<ByteArrayFieldExpression<TEntity>>
    {
        #region constructors
        public ByteArrayFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {
        }

        protected ByteArrayFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {
        }
        #endregion

        #region as
        public new ByteArrayFieldExpression<TEntity> As(string alias)
            => new ByteArrayFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(ByteArrayFieldExpression<TEntity> obj)
            => obj is ByteArrayFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteArrayFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
