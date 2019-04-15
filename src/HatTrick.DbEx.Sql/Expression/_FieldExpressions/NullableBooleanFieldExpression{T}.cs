using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableBooleanFieldExpression<TEntity> : NullableFieldExpression<TEntity, bool>,
        ISupportedForSelectEntityExpression<TEntity, bool>,
        ISupportedForSelectFieldExpression<bool>,
        ISupportedForExpression<AssignmentExpression, TEntity, bool>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, bool>,
        ISupportedForFunctionExpression<CastFunctionExpression, bool>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, bool>,
        ISupportedForFunctionExpression<CountFunctionExpression, bool>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, bool>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, bool>
        where TEntity : IDbEntity
    {
        public NullableBooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, bool?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableBooleanFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, bool?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableBooleanFieldExpression<TEntity> As(string alias) => new NullableBooleanFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
