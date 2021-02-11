using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeFieldExpression<TEntity> : 
        DateTimeFieldExpression,
        IEquatable<DateTimeFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DateTimeFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override DateTimeElement As(string alias)
            => new DateTimeSelectExpression(this).As(alias);
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
