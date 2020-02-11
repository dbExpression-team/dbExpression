using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableFloatFieldExpression<TEntity> : NullableFloatFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, float?>,
        ISupportedForExpression<AssignmentExpression, TEntity, float?>
        where TEntity : IDbEntity
    {
        public NullableFloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, float?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableFloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, float?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableFloatFieldExpression<TEntity> As(string alias) => new NullableFloatFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
