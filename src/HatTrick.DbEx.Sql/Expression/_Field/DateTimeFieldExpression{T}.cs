using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeFieldExpression<TEntity> : 
        DateTimeFieldExpression,
        IEquatable<DateTimeFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DateTimeFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private DateTimeFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override DateTimeElement As(string alias)
            => new DateTimeFieldExpression<TEntity>(base.identifier, base.entity, alias);
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
