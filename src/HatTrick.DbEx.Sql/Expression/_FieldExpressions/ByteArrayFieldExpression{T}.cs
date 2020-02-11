using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : ByteArrayFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, byte[]>,
        ISupportedForExpression<AssignmentExpression, TEntity, byte[]>
        where TEntity : IDbEntity
    {
        public ByteArrayFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, byte[]>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected ByteArrayFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, byte[]>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {
        }

        #region as
        public virtual ByteArrayFieldExpression<TEntity> As(string alias) => new ByteArrayFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
