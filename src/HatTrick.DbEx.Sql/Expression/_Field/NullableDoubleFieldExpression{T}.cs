using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleFieldExpression<TEntity> : 
        NullableDoubleFieldExpression,
        IEquatable<NullableDoubleFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableDoubleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private NullableDoubleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableDoubleFieldExpression<TEntity> As(string alias)
            => new NullableDoubleFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleFieldExpression<TEntity> obj)
            => obj is NullableDoubleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
