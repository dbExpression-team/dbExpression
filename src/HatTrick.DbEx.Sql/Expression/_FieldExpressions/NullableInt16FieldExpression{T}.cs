using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableInt16FieldExpression<TEntity> : NullableFieldExpression<TEntity, short>,
        ISupportedForSelectEntityExpression<TEntity, short>,
        ISupportedForSelectFieldExpression<short>,
        ISupportedForExpression<AssignmentExpression, TEntity, short>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, short>,
        ISupportedForFunctionExpression<CastFunctionExpression, short>,
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
        public NullableInt16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, short?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableInt16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, short?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableInt16FieldExpression<TEntity> As(string alias) => new NullableInt16FieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
