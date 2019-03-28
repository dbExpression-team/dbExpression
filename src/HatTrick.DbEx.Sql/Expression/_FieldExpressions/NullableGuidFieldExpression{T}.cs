using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableGuidFieldExpression<TEntity> : NullableFieldExpression<TEntity, Guid>,
        ISupportedForSelectExpression<TEntity, Guid>,
        ISupportedForExpression<AssignmentExpression, TEntity, Guid>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid>,
        ISupportedForFunctionExpression<CountFunctionExpression, Guid>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, Guid>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, Guid>
        where TEntity : IDbEntity
    {
        public NullableGuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, Guid?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableGuidFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, Guid?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableGuidFieldExpression<TEntity> As(string alias) => new NullableGuidFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
