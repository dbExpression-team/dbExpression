using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class Int16FieldExpression<TEntity> : FieldExpression<TEntity, short>,
        ISupportedForSelectExpression<TEntity, short>,
        ISupportedForExpression<AssignmentExpression, TEntity, short>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, short>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, short>,
        ISupportedForFunctionExpression<CountFunctionExpression, short>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, short>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, short>,
        ISupportedForFunctionExpression<AverageFunctionExpression, short>,
        ISupportedForFunctionExpression<SumFunctionExpression, short>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, short>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, short>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, short>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, short>
        where TEntity : IDbEntity
    {
        public Int16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, short>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected Int16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, short>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual Int16FieldExpression<TEntity> As(string alias) => new Int16FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
