using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableDateTimeFieldExpression<TEntity> : NullableDateTimeFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, DateTime?>,
        ISupportedForExpression<AssignmentExpression, TEntity, DateTime>
        where TEntity : IDbEntity
    {
        public NullableDateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, DateTime?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, DateTime?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableDateTimeFieldExpression<TEntity> As(string alias) => new NullableDateTimeFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
