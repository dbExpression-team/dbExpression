using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class DateTimeOffsetFieldExpression<TEntity> : FieldExpression<TEntity, DateTimeOffset>,
        ISupportedForSelectEntityExpression<TEntity, DateTimeOffset>,
        ISupportedForSelectFieldExpression<DateTimeOffset>,
        ISupportedForExpression<AssignmentExpression, TEntity, DateTimeOffset>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTimeOffset>
        where TEntity : IDbEntity
    {
        public DateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, DateTimeOffset>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, DateTimeOffset>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual DateTimeOffsetFieldExpression<TEntity> As(string alias) => new DateTimeOffsetFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
