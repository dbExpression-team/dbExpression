using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class DecimalFieldExpression<TEntity> : DecimalFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, decimal>,
        ISupportedForExpression<AssignmentExpression, TEntity, decimal>
        where TEntity : IDbEntity
    {
        public DecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, decimal>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, decimal>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual DecimalFieldExpression<TEntity> As(string alias) => new DecimalFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
