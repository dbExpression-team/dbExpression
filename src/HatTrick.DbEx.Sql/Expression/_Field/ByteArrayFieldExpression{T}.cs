using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : ByteArrayFieldExpression
        where TEntity : IDbEntity,
        IEquatable<ByteArrayFieldExpression<TEntity>>
    {
        #region constructors
        public ByteArrayFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {
        }

        protected ByteArrayFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {
        }
        #endregion

        #region as
        public new ByteArrayFieldExpression<TEntity> As(string alias)
            => new ByteArrayFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
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
