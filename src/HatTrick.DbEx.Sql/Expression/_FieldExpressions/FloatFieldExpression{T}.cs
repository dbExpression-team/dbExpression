using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class FloatFieldExpression<TEntity> : FieldExpression<TEntity, float>,
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
        public FloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, float>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected FloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, float>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual FloatFieldExpression<TEntity> As(string alias) => new FloatFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
