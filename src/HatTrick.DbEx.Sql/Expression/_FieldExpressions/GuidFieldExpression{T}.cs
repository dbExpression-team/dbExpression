using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class GuidFieldExpression<TEntity> : FieldExpression<TEntity, Guid>,
        ISupportedForSelectEntityExpression<TEntity, Guid>,
        ISupportedForSelectFieldExpression<Guid>,
        ISupportedForExpression<AssignmentExpression, TEntity, Guid>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CastFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CountFunctionExpression, Guid>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, Guid>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, Guid>
        where TEntity : IDbEntity
    {
        public GuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, Guid>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected GuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, Guid>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual GuidFieldExpression<TEntity> As(string alias) => new GuidFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
