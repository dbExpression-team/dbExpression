using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableDecimalFieldExpression<TEntity> : NullableDecimalFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, decimal?>,
        ISupportedForExpression<AssignmentExpression, TEntity, decimal?>
        where TEntity : IDbEntity
    {
        public NullableDecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, decimal?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, decimal?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableDecimalFieldExpression<TEntity> As(string alias) => new NullableDecimalFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
