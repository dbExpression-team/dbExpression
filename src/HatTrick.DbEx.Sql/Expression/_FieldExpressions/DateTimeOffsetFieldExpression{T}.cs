using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class DateTimeOffsetFieldExpression<TEntity> : DateTimeOffsetFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, DateTimeOffset>,
        ISupportedForExpression<AssignmentExpression, TEntity, DateTimeOffset>
        where TEntity : IDbEntity
    {
        public DateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, DateTimeOffset>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, DateTimeOffset>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual DateTimeOffsetFieldExpression<TEntity> As(string alias) => new DateTimeOffsetFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
