using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class ByteFieldExpression<TEntity> : FieldExpression<TEntity, byte>,
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
        public ByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, byte>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected ByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, byte>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual ByteFieldExpression<TEntity> As(string alias) => new ByteFieldExpression<TEntity>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
