using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class DoubleFieldExpression<TEntity> : DoubleFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, double>,
        ISupportedForExpression<AssignmentExpression, TEntity, double>
        where TEntity : IDbEntity
    {
        public DoubleFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, double>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DoubleFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, double>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual DoubleFieldExpression<TEntity> As(string alias) => new DoubleFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
