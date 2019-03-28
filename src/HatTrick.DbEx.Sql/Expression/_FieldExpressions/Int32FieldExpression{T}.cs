using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class Int32FieldExpression<TEntity> : FieldExpression<TEntity, int>,
        ISupportedForSelectExpression<TEntity, int>,
        //ISupportedForExpression<AssignmentExpression, TEntity, int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int>,
        ISupportedForFunctionExpression<CountFunctionExpression, int>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, int>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, int>,
        ISupportedForFunctionExpression<AverageFunctionExpression, int>,
        ISupportedForFunctionExpression<SumFunctionExpression, int>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, int>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, int>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, int>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, int>
        where TEntity : IDbEntity
    {
        public Int32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, int>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected Int32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, int>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual Int32FieldExpression<TEntity> As(string alias) => new Int32FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
