using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class StringFieldExpression<TEntity> : FieldExpression<TEntity, string>,
        ISupportedForSelectEntityExpression<TEntity, string>,
        ISupportedForSelectFieldExpression<string>,
        ISupportedForExpression<AssignmentExpression, TEntity, string>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, string>,
        ISupportedForFunctionExpression<CastFunctionExpression, string>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, string>,
        ISupportedForFunctionExpression<CountFunctionExpression, string>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, string>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, string>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, string>
        where TEntity : IDbEntity
    {
        public StringFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, string>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected StringFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, string>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual StringFieldExpression<TEntity> As(string alias) => new StringFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
