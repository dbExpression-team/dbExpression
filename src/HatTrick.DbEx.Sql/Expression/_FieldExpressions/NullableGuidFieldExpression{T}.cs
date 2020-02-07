using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableGuidFieldExpression<TEntity> : NullableGuidFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, Guid?>,
        ISupportedForExpression<AssignmentExpression, TEntity, Guid?>
        where TEntity : IDbEntity
    {
        public NullableGuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, Guid?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableGuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, Guid?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableGuidFieldExpression<TEntity> As(string alias) => new NullableGuidFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
