using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class FloatFieldExpression<TEntity> : FloatFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, float>,
        ISupportedForExpression<AssignmentExpression, TEntity, float>
        where TEntity : IDbEntity
    {
        public FloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, float>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected FloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, float>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual FloatFieldExpression<TEntity> As(string alias) => new FloatFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
