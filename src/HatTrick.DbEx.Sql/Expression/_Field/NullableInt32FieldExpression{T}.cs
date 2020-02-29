using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32FieldExpression<TEntity> : 
        NullableInt32FieldExpression,
        IEquatable<NullableInt32FieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableInt32FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private NullableInt32FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableInt32FieldExpression<TEntity> As(string alias)
            => new NullableInt32FieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32FieldExpression<TEntity> obj)
            => obj is NullableInt32FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
