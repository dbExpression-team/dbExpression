using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableDecimalFieldExpression<TEntity> : NullableFieldExpression<TEntity, decimal>,
        ISupportedForSelectEntityExpression<TEntity, decimal>,
        ISupportedForSelectFieldExpression<decimal>,
        ISupportedForExpression<AssignmentExpression, TEntity, decimal>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, decimal>,
        ISupportedForFunctionExpression<CastFunctionExpression, decimal>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal>,
        ISupportedForFunctionExpression<CountFunctionExpression, decimal>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, decimal>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, decimal>,
        ISupportedForFunctionExpression<AverageFunctionExpression, decimal>,
        ISupportedForFunctionExpression<SumFunctionExpression, decimal>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, decimal>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, decimal>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, decimal>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, decimal>
        where TEntity : IDbEntity
    {
        public NullableDecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, decimal?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, decimal?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableDecimalFieldExpression<TEntity> As(string alias) => new NullableDecimalFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
