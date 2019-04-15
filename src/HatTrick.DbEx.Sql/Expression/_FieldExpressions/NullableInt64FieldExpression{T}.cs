using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableInt64FieldExpression<TEntity> : NullableFieldExpression<TEntity, long>,
        ISupportedForSelectEntityExpression<TEntity, long>,
        ISupportedForExpression<AssignmentExpression, TEntity, long>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, long>,
        ISupportedForFunctionExpression<CastFunctionExpression, long>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, long>,
        ISupportedForFunctionExpression<CountFunctionExpression, long>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, long>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, long>,
        ISupportedForFunctionExpression<AverageFunctionExpression, long>,
        ISupportedForFunctionExpression<SumFunctionExpression, long>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, long>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, long>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, long>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, long>
        where TEntity : IDbEntity
    {
        public NullableInt64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, long?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableInt64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, long?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableInt64FieldExpression<TEntity> As(string alias) => new NullableInt64FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
