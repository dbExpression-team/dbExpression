using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeFieldExpression<TEntity> : 
        DateTimeFieldExpression,
        IEquatable<DateTimeFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public DateTimeFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        private DateTimeFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion
        
        #region as
        public new DateTimeFieldExpression<TEntity> As(string alias)
            => new DateTimeFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(DateTimeFieldExpression<TEntity> obj)
            => obj is DateTimeFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
