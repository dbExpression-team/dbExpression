using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetFieldExpression<TEntity> : 
        DateTimeOffsetFieldExpression,
        IEquatable<DateTimeOffsetFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public DateTimeOffsetFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private DateTimeOffsetFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public DateTimeOffsetFieldExpression<TEntity> As(string alias)
            => new DateTimeOffsetFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetFieldExpression<TEntity> obj)
            => obj is DateTimeOffsetFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
