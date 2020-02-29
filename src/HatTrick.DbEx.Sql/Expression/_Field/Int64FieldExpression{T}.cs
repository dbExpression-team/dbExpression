using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64FieldExpression<TEntity> : 
        Int64FieldExpression,
        IEquatable<Int64FieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public Int64FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private Int64FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new Int64FieldExpression<TEntity> As(string alias)
            => new Int64FieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(Int64FieldExpression<TEntity> obj)
            => obj is Int64FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
