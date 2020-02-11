using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableDoubleFieldExpression<TEntity> : NullableDoubleFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, double?>,
        ISupportedForExpression<AssignmentExpression, TEntity, double?>
        where TEntity : IDbEntity
    {
        public NullableDoubleFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, double?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDoubleFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, double?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableDoubleFieldExpression<TEntity> As(string alias) => new NullableDoubleFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
