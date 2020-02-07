using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class GuidFieldExpression<TEntity> : GuidFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, Guid>,
        ISupportedForExpression<AssignmentExpression, TEntity, Guid>
        where TEntity : IDbEntity
    {
        public GuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, Guid>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected GuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, Guid>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual GuidFieldExpression<TEntity> As(string alias) => new GuidFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
