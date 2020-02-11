using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class BooleanFieldExpression<TEntity> : BooleanFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, bool>,
        ISupportedForExpression<AssignmentExpression, TEntity, bool>
        where TEntity : IDbEntity
    {
        public BooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, bool>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected BooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, bool>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual BooleanFieldExpression<TEntity> As(string alias) => new BooleanFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
