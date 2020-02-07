using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class Int16FieldExpression<TEntity> : Int16FieldExpression,
        ISupportedForSelectEntityExpression<TEntity, short>,
        ISupportedForExpression<AssignmentExpression, TEntity, short>
        where TEntity : IDbEntity
    {
        public Int16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, short>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected Int16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, short>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual Int16FieldExpression<TEntity> As(string alias) => new Int16FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
