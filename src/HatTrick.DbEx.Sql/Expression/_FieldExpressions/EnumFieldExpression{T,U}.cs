using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class EnumFieldExpression<TEntity, TEnum> : FieldExpression<TEntity, TEnum>,
        ISupportedForSelectEntityExpression<TEntity, TEnum>,
        ISupportedForSelectFieldExpression<TEnum>,
        ISupportedForExpression<AssignmentExpression, TEntity, TEnum>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<CastFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<CountFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, TEnum>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, TEnum>
        where TEntity : IDbEntity
        where TEnum : Enum
    {
        public EnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, TEnum>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected EnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, TEnum>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual EnumFieldExpression<TEntity,TEnum> As(string alias) => new EnumFieldExpression<TEntity,TEnum>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
