using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleFieldExpression<TEntity> : 
        DoubleFieldExpression,
        IEquatable<DoubleFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public DoubleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private DoubleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new DoubleFieldExpression<TEntity> As(string alias)
            => new DoubleFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(DoubleFieldExpression<TEntity> obj)
            => obj is DoubleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
