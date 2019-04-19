using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class DateTimeFieldExpression<TEntity> : FieldExpression<TEntity, DateTime>,
        ISupportedForSelectEntityExpression<TEntity, DateTime>,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForExpression<AssignmentExpression, TEntity, DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTime>
        where TEntity : IDbEntity
    {
        public DateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, DateTime>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, DateTime>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual DateTimeFieldExpression<TEntity> As(string alias) => new DateTimeFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
