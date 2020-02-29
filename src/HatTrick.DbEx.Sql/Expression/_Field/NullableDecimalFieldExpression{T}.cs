using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalFieldExpression<TEntity> : 
        NullableDecimalFieldExpression,
        IEquatable<NullableDecimalFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableDecimalFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private NullableDecimalFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableDecimalFieldExpression<TEntity> As(string alias)
            => new NullableDecimalFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalFieldExpression<TEntity> obj)
            => obj is NullableDecimalFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
