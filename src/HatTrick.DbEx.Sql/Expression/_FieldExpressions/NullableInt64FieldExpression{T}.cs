using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableInt64FieldExpression<TEntity> : NullableInt64FieldExpression,
        ISupportedForSelectEntityExpression<TEntity, long?>,
        ISupportedForExpression<AssignmentExpression, TEntity, long?>
        where TEntity : IDbEntity
    {
        public NullableInt64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, long?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableInt64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, long?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableInt64FieldExpression<TEntity> As(string alias) => new NullableInt64FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
