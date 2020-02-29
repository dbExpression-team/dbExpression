using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringFieldExpression<TEntity> : 
        StringFieldExpression,
        IEquatable<StringFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public StringFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private StringFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new StringFieldExpression<TEntity> As(string alias)
            => new StringFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(StringFieldExpression<TEntity> obj)
            => obj is StringFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
