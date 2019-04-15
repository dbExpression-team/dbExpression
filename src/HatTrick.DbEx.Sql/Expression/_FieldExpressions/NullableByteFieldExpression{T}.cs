using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableByteFieldExpression<TEntity> : NullableFieldExpression<TEntity, byte>,
        ISupportedForSelectEntityExpression<TEntity, byte>,
        ISupportedForSelectFieldExpression<byte>,
        ISupportedForExpression<AssignmentExpression, TEntity, byte>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, byte>,
        ISupportedForFunctionExpression<CastFunctionExpression, byte>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, byte>,
        ISupportedForFunctionExpression<CountFunctionExpression, byte>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, byte>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, byte>,
        ISupportedForFunctionExpression<AverageFunctionExpression, byte>,
        ISupportedForFunctionExpression<SumFunctionExpression, byte>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, byte>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, byte>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, byte>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, byte>
        where TEntity : IDbEntity
    {
        public NullableByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, byte?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, byte?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableByteFieldExpression<TEntity> As(string alias) => new NullableByteFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
