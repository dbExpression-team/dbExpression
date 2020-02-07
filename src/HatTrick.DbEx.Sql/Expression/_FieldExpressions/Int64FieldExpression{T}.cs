using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class Int64FieldExpression<TEntity> : Int64FieldExpression,
        ISupportedForSelectEntityExpression<TEntity, long>,
        ISupportedForExpression<AssignmentExpression, TEntity, long>
        where TEntity : IDbEntity
    {
        public Int64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, long>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected Int64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, long>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual Int64FieldExpression<TEntity> As(string alias) => new Int64FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
