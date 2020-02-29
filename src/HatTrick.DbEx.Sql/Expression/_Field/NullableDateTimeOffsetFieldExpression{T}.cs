using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetFieldExpression<TEntity> : 
        NullableDateTimeOffsetFieldExpression,
        IEquatable<NullableDateTimeOffsetFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableDateTimeOffsetFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        private NullableDateTimeOffsetFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableDateTimeOffsetFieldExpression<TEntity> As(string alias)
            => new NullableDateTimeOffsetFieldExpression<TEntity>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetFieldExpression<TEntity> obj)
            => obj is NullableDateTimeOffsetFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
