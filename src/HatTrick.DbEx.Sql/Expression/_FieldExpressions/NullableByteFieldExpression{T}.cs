using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableByteFieldExpression<TEntity> : NullableByteFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, byte?>,
        ISupportedForExpression<AssignmentExpression, TEntity, byte?>
        where TEntity : IDbEntity
    {
        public NullableByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, byte?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, byte?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableByteFieldExpression<TEntity> As(string alias) => new NullableByteFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
