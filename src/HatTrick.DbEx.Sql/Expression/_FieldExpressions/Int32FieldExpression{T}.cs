using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class Int32FieldExpression<TEntity> : Int32FieldExpression,
        ISupportedForSelectEntityExpression<TEntity, int>,
        ISupportedForExpression<AssignmentExpression, TEntity, int>
        where TEntity : class, IDbEntity
    {
        public Int32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, int>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected Int32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, int>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual Int32FieldExpression<TEntity> As(string alias) => new Int32FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}

