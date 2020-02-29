using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeFieldExpression<TEntity> : 
        NullableDateTimeFieldExpression,
        IEquatable<NullableDateTimeFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableDateTimeFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private NullableDateTimeFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new NullableDateTimeFieldExpression<TEntity> As(string alias)
            => new NullableDateTimeFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeFieldExpression<TEntity> obj)
            => obj is NullableDateTimeFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
