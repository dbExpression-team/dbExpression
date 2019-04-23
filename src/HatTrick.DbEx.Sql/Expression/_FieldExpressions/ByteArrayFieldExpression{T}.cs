using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : FieldExpression<TEntity, byte[]>,
        ISupportedForSelectEntityExpression<TEntity, byte[]>,
        ISupportedForSelectFieldExpression<byte[]>,
        ISupportedForExpression<AssignmentExpression, TEntity, byte[]>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, byte[]>,
        ISupportedForFunctionExpression<CastFunctionExpression, byte[]>
        where TEntity : IDbEntity
    {
        public ByteArrayFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, byte[]>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected ByteArrayFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, byte[]>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {
        }

        #region as
        public virtual ByteArrayFieldExpression<TEntity> As(string alias) => new ByteArrayFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
