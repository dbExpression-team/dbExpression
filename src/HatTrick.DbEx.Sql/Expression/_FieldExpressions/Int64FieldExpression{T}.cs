using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class Int64FieldExpression<TEntity> : FieldExpression<TEntity, long>,
        ISupportedForSelectExpression<TEntity, long>,
        ISupportedForExpression<AssignmentExpression, TEntity, long>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, long>,
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
        public Int64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, long>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected Int64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, long>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual Int64FieldExpression<TEntity> As(string alias) => new Int64FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
