using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanFieldExpression<TEntity> : 
        TimeSpanFieldExpression,
        IEquatable<TimeSpanFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public TimeSpanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override TimeSpanElement As(string alias)
            => new TimeSpanSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(TimeSpanFieldExpression<TEntity> obj)
            => obj is TimeSpanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
