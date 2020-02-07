using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableBooleanFieldExpression<TEntity> : NullableBooleanFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, bool?>,
        ISupportedForExpression<AssignmentExpression, TEntity, bool?>
        where TEntity : IDbEntity
    {
        public NullableBooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, bool?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableBooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, bool?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableBooleanFieldExpression<TEntity> As(string alias) => new NullableBooleanFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
