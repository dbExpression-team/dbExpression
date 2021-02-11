using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetFieldExpression<TEntity> : 
        DateTimeOffsetFieldExpression,
        IEquatable<DateTimeOffsetFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DateTimeOffsetFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override DateTimeOffsetElement As(string alias)
            => new DateTimeOffsetSelectExpression(this).As(alias);
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
