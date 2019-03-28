using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableDateTimeFieldExpression<TEntity> : NullableFieldExpression<TEntity, DateTime>,
        ISupportedForSelectExpression<TEntity, DateTime>,
        ISupportedForExpression<AssignmentExpression, TEntity, DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTime>
        where TEntity : IDbEntity
    {
        public NullableDateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, DateTime?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, DateTime?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableDateTimeFieldExpression<TEntity> As(string alias) => new NullableDateTimeFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
