using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class ByteFieldExpression<TEntity> : ByteFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, byte>,
        ISupportedForExpression<AssignmentExpression, TEntity, byte>

        where TEntity : IDbEntity
    {
        public ByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, byte>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected ByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, byte>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual ByteFieldExpression<TEntity> As(string alias) => new ByteFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
