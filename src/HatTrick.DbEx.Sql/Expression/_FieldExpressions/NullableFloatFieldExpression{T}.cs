using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableFloatFieldExpression<TEntity> : NullableFieldExpression<TEntity, float>,
        ISupportedForSelectEntityExpression<TEntity, float>,
        ISupportedForSelectFieldExpression<float>,
        ISupportedForExpression<AssignmentExpression, TEntity, float>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, float>,
        ISupportedForFunctionExpression<CastFunctionExpression, float>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, float>,
        ISupportedForFunctionExpression<CountFunctionExpression, float>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, float>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, float>,
        ISupportedForFunctionExpression<AverageFunctionExpression, float>,
        ISupportedForFunctionExpression<SumFunctionExpression, float>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, float>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, float>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, float>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, float>
        where TEntity : IDbEntity
    {
        public NullableFloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, float?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableFloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, float?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableFloatFieldExpression<TEntity> As(string alias) => new NullableFloatFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
