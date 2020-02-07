using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableInt32FieldExpression<TEntity> : NullableInt32FieldExpression,
        ISupportedForSelectEntityExpression<TEntity, int?>,
        ISupportedForExpression<AssignmentExpression, TEntity, int?>
        where TEntity : IDbEntity
    {
        public NullableInt32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, int?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableInt32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, int?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableInt32FieldExpression<TEntity> As(string alias) => new NullableInt32FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
