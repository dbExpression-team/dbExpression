using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DateTimeFieldExpression<TEntity> : DateTimeFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, DateTime>,
        ISupportedForExpression<AssignmentExpression, TEntity, DateTime>
        where TEntity : IDbEntity
    {
        public DateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, DateTime>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        private DateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, DateTime>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual DateTimeFieldExpression<TEntity> As(string alias) => new DateTimeFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
