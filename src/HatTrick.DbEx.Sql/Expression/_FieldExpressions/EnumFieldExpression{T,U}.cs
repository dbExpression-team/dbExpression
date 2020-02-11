using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class EnumFieldExpression<TEntity, TEnum> : EnumFieldExpression<TEnum>,
        ISupportedForSelectEntityExpression<TEntity, TEnum>,
        ISupportedForExpression<AssignmentExpression, TEntity, TEnum>
        where TEntity : IDbEntity
        where TEnum : Enum
    {
        public EnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, TEnum>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected EnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, TEnum>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual EnumFieldExpression<TEntity,TEnum> As(string alias) => new EnumFieldExpression<TEntity,TEnum>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
