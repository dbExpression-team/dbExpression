using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableDateTimeOffsetFieldExpression<TEntity> : NullableFieldExpression<TEntity, DateTimeOffset>,
        ISupportedForSelectExpression<TEntity, DateTimeOffset>,
        ISupportedForExpression<AssignmentExpression, TEntity, DateTimeOffset>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTimeOffset>
        where TEntity : IDbEntity
    {
        public NullableDateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, DateTimeOffset?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, DateTimeOffset?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableDateTimeOffsetFieldExpression<TEntity> As(string alias) => new NullableDateTimeOffsetFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
