using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class StringFieldExpression<TEntity> : StringFieldExpression,
        ISupportedForSelectEntityExpression<TEntity, string>,
        ISupportedForExpression<AssignmentExpression, TEntity, string>
        where TEntity : IDbEntity
    {
        public StringFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, string>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected StringFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, string>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual StringFieldExpression<TEntity> As(string alias) => new StringFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
