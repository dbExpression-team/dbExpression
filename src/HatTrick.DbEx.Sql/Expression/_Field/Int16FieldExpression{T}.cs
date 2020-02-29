using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16FieldExpression<TEntity> : 
        Int16FieldExpression,
        IEquatable<Int16FieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public Int16FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private Int16FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new Int16FieldExpression<TEntity> As(string alias)
            => new Int16FieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(Int16FieldExpression<TEntity> obj)
            => obj is Int16FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
