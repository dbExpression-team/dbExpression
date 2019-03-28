using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableEnumFieldExpression<TEntity, TEnum> : NullableFieldExpression<TEntity, TEnum>,
        ISupportedForSelectExpression<TEntity, TEnum>,
        ISupportedForExpression<AssignmentExpression, TEntity, TEnum>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<CountFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<AverageFunctionExpression, TEnum>
        where TEntity : IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        public NullableEnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, TEnum?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableEnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, TEnum?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableEnumFieldExpression<TEntity, TEnum> As(string alias) => new NullableEnumFieldExpression<TEntity, TEnum>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
