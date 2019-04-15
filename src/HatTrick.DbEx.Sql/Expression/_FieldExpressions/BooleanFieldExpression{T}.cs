using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class BooleanFieldExpression<TEntity> : FieldExpression<TEntity, bool>,
        ISupportedForSelectEntityExpression<TEntity, bool>,
        ISupportedForSelectFieldExpression<bool>,
        ISupportedForExpression<AssignmentExpression, TEntity, bool>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, bool>,
        ISupportedForFunctionExpression<CastFunctionExpression, bool>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, bool>,
        ISupportedForFunctionExpression<CountFunctionExpression, bool>
        where TEntity : IDbEntity
    {
        public BooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, bool>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected BooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, bool>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual BooleanFieldExpression<TEntity> As(string alias) => new BooleanFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
