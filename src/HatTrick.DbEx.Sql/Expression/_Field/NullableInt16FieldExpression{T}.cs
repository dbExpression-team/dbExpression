using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16FieldExpression<TEntity> : 
        NullableInt16FieldExpression,
        IEquatable<NullableInt16FieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableInt16FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private NullableInt16FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableInt16FieldExpression<TEntity> As(string alias)
            => new NullableInt16FieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16FieldExpression<TEntity> obj)
            => obj is NullableInt16FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
