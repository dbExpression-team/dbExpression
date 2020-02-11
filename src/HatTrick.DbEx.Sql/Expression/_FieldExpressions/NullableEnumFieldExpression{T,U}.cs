using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableEnumFieldExpression<TEntity, TEnum> : NullableEnumFieldExpression<TEnum>,
        ISupportedForSelectEntityExpression<TEntity, TEnum?>,
        ISupportedForExpression<AssignmentExpression, TEntity, TEnum?>
        where TEntity : IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        public NullableEnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, TEnum?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableEnumFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, TEnum?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region as
        public virtual NullableEnumFieldExpression<TEntity, TEnum> As(string alias) => new NullableEnumFieldExpression<TEntity, TEnum>(base.Entity, base.Metadata, Mapper, alias);
        #endregion
    }
}
