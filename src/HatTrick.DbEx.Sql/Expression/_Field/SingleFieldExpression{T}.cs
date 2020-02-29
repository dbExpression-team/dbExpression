using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleFieldExpression<TEntity> : 
        SingleFieldExpression,
        IEquatable<SingleFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public SingleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private SingleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new SingleFieldExpression<TEntity> As(string alias)
            => new SingleFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(SingleFieldExpression<TEntity> obj)
            => obj is SingleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
