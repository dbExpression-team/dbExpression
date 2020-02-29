using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalFieldExpression<TEntity> : 
        DecimalFieldExpression,
        IEquatable<DecimalFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public DecimalFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private DecimalFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new DecimalFieldExpression<TEntity> As(string alias)
            => new DecimalFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(DecimalFieldExpression<TEntity> obj)
            => obj is DecimalFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
